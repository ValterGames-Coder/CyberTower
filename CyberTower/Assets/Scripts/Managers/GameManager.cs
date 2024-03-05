using System;
using System.Collections.Generic;
using InstantGamesBridge;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Wait,
    Play,
    Win,
    Lose
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _towers;
    private Transform _tower;
    [SerializeField] private int _debugLevel;
    [SerializeField] private TMP_Text _soulsText;
    [SerializeField] private float _damageToSoul;
    private float _towerDamage;

    private MoneyManager _moneyManager;
    
    public Transform Tower => _tower;

    public GameState State { get; private set; }
    public int CurrentLevel { get; private set; }
    public int CurrentWave { get; private set; }
    public List<GameObject> units = new();
    public int souls { get; private set; }
    
    
    public event Action OnLoadLevel;
    public event Action OnPlayWave; 
    public event Action OnWaitWave; 
    public event Action OnWin; 
    public event Action OnLose;
    public event Action OnChangeSouls; 

    private void Start()
    {
        _moneyManager = FindObjectOfType<MoneyManager>();
        Bridge.storage.Get("Level", OnStorageGetCompleted);
        _tower = _towers[CurrentLevel];
        _tower.gameObject.SetActive(true);
        _tower.GetComponent<Health>().OnDamage += damage => _towerDamage += damage;
        _soulsText.text = souls.ToString();
        OnLoadLevel?.Invoke();
    }

    public bool CheckSouls(Unit unit) => souls >= unit.soul;

    public void BuySouls(int remove)
    {
        souls -= remove;
        OnChangeSouls?.Invoke();
        _soulsText.text = souls.ToString();
    }

    public void SetSouls(int add)
    {
        if (add > 0)
        {
            souls += add;
            OnChangeSouls?.Invoke();
            _soulsText.text = souls.ToString();
        }
    }

    private void OnStorageGetCompleted(bool success, string data)
    {
        // Загрузка произошла успешно
        if (success)
        {
            if (data != null)
            {
                CurrentLevel = _debugLevel != -1 ? _debugLevel : int.Parse(data);
                Debug.Log(data);
            }
            else
            {
                CurrentLevel = 0;
            }
        }
        else
        {
            CurrentLevel = 0;
        }
    }

    public void SetState(GameState state) => State = state;

    public void WinGame()
    {
        if (CurrentLevel != 5)
        {
            Bridge.storage.Set("Level", CurrentLevel + 1, OnStorageSetCompleted);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        print("Win");
        State = GameState.Win;
        OnWin?.Invoke();
    }
    
    private void OnStorageSetCompleted(bool success)
    {
        Debug.Log($"Level, success: {success}");
    }
    
    private void LoseGame()
    {
        State = GameState.Lose;
        OnLose?.Invoke();
    }

    public void DeleteAndCheckUnits(GameObject unit)
    {
        units.Remove(unit);
        if (units.Count <= 0)
        {
            if (_moneyManager.money <= 0)
            {
                LoseGame();
            }
            else
            {
                if (State != GameState.Lose || State != GameState.Win)
                {
                    State = GameState.Wait;
                    OnWaitWave?.Invoke();
                    CurrentWave++;
                    souls += Mathf.RoundToInt(_towerDamage / _damageToSoul);
                    _towerDamage = 0;
                    _soulsText.text = souls.ToString();
                }
            }
        }
    }

    public void PlayWave()
    {
        State = GameState.Play;
        OnPlayWave?.Invoke();
    }
}
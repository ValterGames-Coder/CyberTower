using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

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
    [SerializeField] private Button _attackButton;
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
        if (YandexGame.SDKEnabled)
        {
            LoadLevel();
        }
        _tower = _towers[CurrentLevel];
        _tower.gameObject.SetActive(true);
        _tower.GetComponent<Health>().OnDamage += damage => _towerDamage += damage;
        OnLoadLevel?.Invoke();
        _soulsText.text = souls.ToString();
    }

    private void LoadLevel()
    {
        CurrentLevel = _debugLevel != -1 ? _debugLevel : YandexGame.savesData.level;
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

    public void SetState(GameState state) => State = state;

    public void SecondLife()
    {
        SetState(GameState.Wait);
        OnWaitWave?.Invoke();
        OnChangeSouls?.Invoke();
    }

    public void WinGame()
    {
        if (CurrentLevel != 5)
        {
            YandexGame.savesData.level = CurrentLevel + 1;
            YandexGame.SaveProgress();
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        print("Win");
        State = GameState.Win;
        OnWin?.Invoke();
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
            CheckUnits();
            souls += Mathf.RoundToInt(_towerDamage / _damageToSoul);
            _towerDamage = 0;
            _soulsText.text = souls.ToString();
            OnChangeSouls?.Invoke();
            if (_moneyManager.money < 10 || souls < 1)
            {
                if (State != GameState.Win)
                    LoseGame();
            }
            else
            {
                if (State != GameState.Lose || State != GameState.Win)
                {
                    State = GameState.Wait;
                    OnWaitWave?.Invoke();
                    CurrentWave++;
                }
            }
        }
    }

    public void PlayWave()
    {
        State = GameState.Play;
        OnPlayWave?.Invoke();
    }

    public void CheckUnits()
    {
        _attackButton.interactable = units.Count > 0;
    }
}
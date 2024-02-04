using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameState
{
    Wait,
    Play,
    Win,
    Lose
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _tower;
    [SerializeField] private int _debugLevel;
    [SerializeField] private TMP_Text _waveText;

    private MoneyManager _moneyManager;
    
    public Transform Tower => _tower;

    public GameState State { get; private set; }
    public int CurrentLevel { get; private set; }
    public int CurrentWave { get; private set; }
    public List<GameObject> units = new();
    public event Action OnLoadLevel;
    public event Action OnPlayWave; 
    public event Action OnWaitWave; 
    public event Action OnWin; 
    public event Action OnLose; 

    private void Start()
    {
        _moneyManager = FindObjectOfType<MoneyManager>();
        if(!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 2);
        CurrentLevel = PlayerPrefs.GetInt("Level");
        if (_debugLevel != -1)
        {
            CurrentLevel = _debugLevel;
        }
        OnLoadLevel?.Invoke();
    }

    public void SetState(GameState state) => State = state;

    public void WinGame()
    {
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
            if (_moneyManager.money <= 0)
            {
                LoseGame();
            }
            else
            {
                State = GameState.Wait;
                OnWaitWave?.Invoke();
                CurrentWave++;
                _waveText.text = $"{CurrentWave}";
            }
        }
    }

    public void PlayWave()
    {
        State = GameState.Play;
        OnPlayWave?.Invoke();
    }
}
using System.Collections.Generic;
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

    public Transform Tower => _tower;

    public GameState State { get; private set; }
    public int CurrentLevel { get; private set; }
    public List<GameObject> units = new();
    
    private int _currentLevel;

    public void SetState(GameState state) => State = state;

    public void CheckUnits(GameObject unit)
    {
        units.Remove(unit);
        if (units.Count <= 0)
        {
            State = GameState.Wait;
        }
    }

    public void PlayWave()
    {
        State = GameState.Play;
    }
}
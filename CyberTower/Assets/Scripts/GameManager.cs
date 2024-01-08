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
    public GameState State;
    public Transform tower;
}
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
    public GameState State = GameState.Wait;
    public Transform tower;
    public int currentLevel;

    public void PlayWave()
    {
        State = GameState.Play;
    }
}
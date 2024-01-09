using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameManager _gameManager;
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _gameManager = FindObjectOfType<GameManager>();

        _health.OnDied += () => _gameManager.SetState(GameState.Win);
    }
}
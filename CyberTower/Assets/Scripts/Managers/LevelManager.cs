using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private List<int> _souls;
    [SerializeField] private List<int> _moneys;

    private void Awake()
    {
        _gameManager.OnLoadLevel += Init;
    }

    private void Init()
    {
        Debug.Log("Init");
        _moneyManager.SetMoney(_moneys[_gameManager.CurrentLevel]);
        _gameManager.SetSouls(_souls[_gameManager.CurrentLevel]);
    }
}
using System;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int _debugMoney = -1;
    [SerializeField] private TMP_Text _moneyText;
    public int money { get; private set;  }
    public event Action OnChangeMoney;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("Money"))
            PlayerPrefs.SetInt("Money", 0);
        money = PlayerPrefs.GetInt("Money");
        if (_debugMoney != -1)
            money = _debugMoney;
        _moneyText.text = $"{money}";
    }
    
    public bool CheckUnitPrice(Unit unit) => money >= unit.price;

    public void BuyUnit(Unit unit)
    {
        money -= unit.price;
        _moneyText.text = $"{money}";
        OnChangeMoney?.Invoke();
    }
}
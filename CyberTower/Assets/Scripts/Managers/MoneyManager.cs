using System;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int _debugMoney = -1;
    [SerializeField] private TMP_Text _moneyText;
    public int money { get; private set;  }
    public event Action OnChangeMoney;

    public void SetMoney(int add)
    {
        if (add > 0)
        {
            money += add;
            OnChangeMoney?.Invoke();
            _moneyText.text = $"{money}";
        }
    }

    private void Start()
    {
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
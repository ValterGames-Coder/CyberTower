using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    private Health _health;
    private float _startHealth;

    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _backHealthBar;
    [SerializeField] private float _lerpSpeed;
    
    private void Start()
    {
        _health = GetComponent<Health>();
        _startHealth = _health.GetHealthPoint();
        _health.IsDamage += UpdateBar;
    }

    private void Update()
    {
        if (Math.Abs(_backHealthBar.fillAmount - _healthBar.fillAmount) > .001f)
        {
            _backHealthBar.fillAmount = Mathf.Lerp(_backHealthBar.fillAmount, _health.GetHealthPoint() / _startHealth, _lerpSpeed);
        }
    }

    private void UpdateBar()
    {
        _healthBar.fillAmount = _health.GetHealthPoint() / _startHealth;
    }
}
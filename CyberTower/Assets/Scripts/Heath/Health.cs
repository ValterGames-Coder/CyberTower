using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    private float _startHealth;
    public event Action<float> OnDamage;
    public event Action OnDied;
    
    public float GetHealthPoint() => _health;

    private void Start()
    {
        _startHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        OnDamage?.Invoke(damage);
        if (_health < 0)
        {
            _health = 0;
            OnDied?.Invoke();
        }
    }

    public void SecondLife() => _health = _startHealth;
}
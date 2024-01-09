using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    public event Action OnDamage;
    public event Action OnDied;
    
    public float GetHealthPoint() => _health;
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        OnDamage?.Invoke();
        if (_health < 0)
        {
            _health = 0;
            OnDied?.Invoke();
        }
    }
}
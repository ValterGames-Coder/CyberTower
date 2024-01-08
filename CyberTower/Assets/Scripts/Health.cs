using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    public event Action IsDamage;
    public event Action IsDied;
    
    public float GetHealthPoint() => _health;
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        IsDamage?.Invoke();
        if (_health < 0)
        {
            _health = 0;
            IsDied?.Invoke();
        }
    }
}
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    
    public float GetHealthPoint() => _health;
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _health = 0;
        }
    }
}
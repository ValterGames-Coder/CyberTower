using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private float _damage;
    
    public void Init(float speed, float damage)
    {
        _speed = speed;
        _damage = damage;
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tower"))
        {
            Health towerHealth = other.GetComponent<Health>();
            towerHealth.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
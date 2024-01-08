using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private float _damage;
    private string _who;
    
    public void Init(float speed, float damage, string who)
    {
        _speed = speed;
        _damage = damage;
        _who = who;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_who))
        {
            Health towerHealth = other.GetComponent<Health>();
            towerHealth.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
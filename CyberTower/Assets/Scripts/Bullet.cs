using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private float _damage;
    private string _who;
    private float _timeLife;
    private GameObject _hit;
    
    public void Init(float speed, float damage, string who, GameObject hit)
    {
        _speed = speed;
        _damage = damage;
        _who = who;
        _hit = hit;
    }

    private void FixedUpdate()
    {
        _timeLife += Time.deltaTime;
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        if (_timeLife > 5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_who))
        {
            Health towerHealth = other.GetComponent<Health>();
            towerHealth.TakeDamage(_damage);
            if (_hit != null)
                Instantiate(_hit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.CompareTag("Floor"))
        {
            if (_hit != null)
                Instantiate(_hit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
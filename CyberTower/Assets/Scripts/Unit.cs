using System;
using System.Collections;
using UnityEngine;
using NaughtyAttributes;
using Random = UnityEngine.Random;

public enum AttackType
{
    Near,
    Far
}

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Unit : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 _stoppedDistance = new (4f, 12f);
    private float _randomStoppedDistance;
    [SerializeField] private bool _isFlying;
    [SerializeField, EnableIf("_isFlying")] private float _flyHeight;

    [Header("Attack")] 
    [SerializeField] private float _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _defaultTimeReload;
    private float _timeReload;
    [SerializeField] private float _spread;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    
    [SerializeField] private Animator _animator;
    private GameManager _game;

    private void Start()
    {
        _game = FindObjectOfType<GameManager>();
        _randomStoppedDistance = Random.Range(_stoppedDistance.x, _stoppedDistance.y);
        if (_isFlying)
        {
            var vector3 = transform.position;
            vector3.y += Random.Range(-_flyHeight, _flyHeight);
            transform.position = vector3;
        }
    }

    private void FixedUpdate()
    {
        if (_game.tower.position.x - transform.position.x > _randomStoppedDistance)
        {
            Vector3 position = transform.position;
            Vector2 target = new Vector2(_game.tower.position.x, position.y);
            position = Vector3.MoveTowards(position, target , _speed * Time.deltaTime);
            transform.position = position;
        }
        else
        {
            _timeReload -= Time.deltaTime;
            if (_timeReload <= 0)
            {
                _animator.SetTrigger("Attack");
                _timeReload = _defaultTimeReload;
            }
        }
        _animator.SetFloat("Speed", _game.tower.position.x - transform.position.x > _randomStoppedDistance ? 1 : 0);
    }

    private void Attack()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.Euler(0,0, _spawnPoint.localRotation.z + Random.Range(-_spread/10, _spread*2)));
        bullet.Init(_bulletSpeed, _damage);
    }

    private void AutoDestroy() => Destroy(gameObject);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Tower"))
        {
            _randomStoppedDistance = 10;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[RequireComponent(
    typeof(Rigidbody2D),
    typeof(Collider2D),
    typeof(Health))]
public class Unit : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 _stoppedDistance = new (4f, 12f);
    public float spawnY;
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
    [SerializeField] private AudioClip _shootAudio;
    [SerializeField] private AudioClip _hitAudio;
    [SerializeField] private GameObject _hit;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    
    public int price;
    public int soul;
    public Sprite avatar;
    
    private GameManager _gameManager;
    private bool _isDied;
    private Health _health;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _health = GetComponent<Health>();
        _health.OnDied += Died;
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
        if (_gameManager.State == GameState.Play)
        {
            if (_gameManager.Tower.position.x - transform.position.x > _randomStoppedDistance)
            {
                Vector3 position = transform.position;
                Vector2 target = new Vector2(_gameManager.Tower.position.x, position.y);
                position = Vector3.MoveTowards(position, target, _speed * Time.deltaTime);
                transform.position = position;
            }
            else
            {
                _timeReload -= Time.deltaTime;
                if (_timeReload <= 0 && _isDied == false)
                {
                    _animator.SetTrigger("Attack");
                    _timeReload = _defaultTimeReload;
                }
            }
            
            _animator.SetFloat("Speed", _gameManager.Tower.position.x - transform.position.x > _randomStoppedDistance ? 1 : 0);
        }
    }

    private void Attack()
    {
        _spawnPoint.rotation = Quaternion.Euler(0, 0, -90 + Random.Range(-_spread / 10, _spread * 2));
        Bullet bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        bullet.Init(_bulletSpeed, _damage, "Tower", _hit);
        _audioSource.clip = _shootAudio;
        _audioSource.pitch = Random.Range(0.75f, 1.75f);
        _audioSource.Play();
    }

    private void Died()
    {
        _speed = 0;
        _isDied = true;
        if (_isFlying)
        {
            _rigidbody.gravityScale = 1;
        }
        _animator.SetTrigger("Died");
    }

    private void AutoDestroy() => Destroy(gameObject);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Tower"))
        {
            _randomStoppedDistance = 10;
        }
    }

    private void OnDestroy() => _gameManager.DeleteAndCheckUnits(gameObject);
    
}

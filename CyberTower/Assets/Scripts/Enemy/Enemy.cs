using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attack")] [SerializeField] private float _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _defaultTimeReload;
    private float _timeReload;
    [SerializeField] private float _spread;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private GameObject _hit;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private EnemyRaycastZone _raycastZone;
    private AudioSource _audio;
    private int _currentUnitCount = -1;
    private Collider2D _currentUnit;
    private GameManager _game;

    private void Start()
    {
        _game = FindObjectOfType<GameManager>();
        _audio = GetComponent<AudioSource>();
    }
    
    private void Attack()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        bullet.Init(_bulletSpeed, _damage, "Unit", _hit);
        _audio.Play();
    }

    private void Update()
    {
        if (_raycastZone.units.Length > 0 && _currentUnitCount == -1)
        {
            _currentUnitCount = Random.Range(0, _raycastZone.units.Length);
            _currentUnit = _raycastZone.units[_currentUnitCount];
        }
        
        if (_currentUnit != null)
        {
            Vector3 direction = transform.position - _currentUnit.transform.position;
            var rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, rot);
            //_spawnPoint.rotation = rotation;
            transform.rotation = rotation;
                    
            _timeReload -= Time.deltaTime;
            if (_timeReload <= 0)
            {
                Attack();
                _timeReload = _defaultTimeReload;
            }
        }
        else
        {
            _currentUnitCount = -1;
        }
    }
}
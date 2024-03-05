using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _unitMask;
    [SerializeField] private EnemyRaycastZone _raycastZone;
    private GameManager _gameManager;
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _gameManager = FindObjectOfType<GameManager>();
        _raycastZone._attackRadius = _attackRadius;
        _raycastZone._unitMask = _unitMask;
        
        _health.OnDied += () => _gameManager.WinGame();
    }
}
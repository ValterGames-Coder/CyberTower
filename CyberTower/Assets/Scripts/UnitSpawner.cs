using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private List<Unit> _units;
    private Unit _currentUnit;
    private Camera _camera;
    private GameManager _gameManager;
    private List<string> _numbers = new() { "1", "2", "3", "4", "5", "6" };
    private Vector2 _spawnPosition;
    private bool _isMobile;

    private void Start()
    {
        _camera = Camera.main;
        _gameManager = FindObjectOfType<GameManager>();
        _isMobile = Application.isMobilePlatform || Application.platform == RuntimePlatform.WebGLPlayer;
    }

    public void SetUnit(Unit unit)
    {
        _currentUnit = unit;
    }
    
    public void Spawn(Transform position)
    {
        if (_currentUnit == null) return;
        _spawnPosition = new Vector2(_camera.ScreenToWorldPoint(position.position).x, _currentUnit.spawnY);
        Instantiate(_currentUnit, _spawnPosition, Quaternion.identity);
        _currentUnit = null;
    }

    private void Spawn(Vector2 position)
    {
        if (_currentUnit == null) return;
        _spawnPosition = new Vector2(position.x, _currentUnit.spawnY);
        Instantiate(_currentUnit, _spawnPosition, Quaternion.identity);
        _currentUnit = null;
    }

    private void SetUnit(int unitId)
    {
        _currentUnit = _units[unitId];
    }

    private void Update()
    {
        if (_currentUnit != null && Input.GetMouseButtonDown(0) && _isMobile == false)
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Spawn(mousePosition);
        }

        if (Input.anyKey)
        {
            if (_numbers.Contains(Input.inputString))
            {
                SetUnit(int.Parse(Input.inputString) - 1);
            }
        }
    }
}
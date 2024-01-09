using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private List<Unit> _units;
    [SerializeField] private List<UnitSpawnButton> _unitButtons;
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

        foreach (UnitSpawnButton unitSpawnButton in _unitButtons)
        {
            unitSpawnButton.unit = _units[_unitButtons.IndexOf(unitSpawnButton)];
        }
    }

    public void SetUnit(Unit unit)
    {
        _currentUnit = unit;
    }
    
    public void Spawn(Transform position)
    {
        if (_currentUnit == null) return;
        _spawnPosition = new Vector2(_camera.ScreenToWorldPoint(position.position).x, _currentUnit.spawnY);
        Unit newUnit = Instantiate(_currentUnit, _spawnPosition, Quaternion.identity);
        _gameManager.units.Add(newUnit.gameObject);
        _currentUnit = null;
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void Spawn(Vector2 position)
    {
        if (_currentUnit == null) return;
        _spawnPosition = new Vector2(position.x, _currentUnit.spawnY);
        Unit newUnit = Instantiate(_currentUnit, _spawnPosition, Quaternion.identity);
        _gameManager.units.Add(newUnit.gameObject);
        _currentUnit = null;
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void SetUnit(int unitId)
    {
        _currentUnit = _units[unitId];
    }

    private void Update()
    {
        if (_isMobile == false)
        {

            if (_currentUnit != null && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                Spawn(mousePosition);
            }

            if (Input.anyKey)
            {
                if (_numbers.Contains(Input.inputString))
                {
                    int id = int.Parse(Input.inputString) - 1;
                    SetUnit(id);
                    EventSystem.current.SetSelectedGameObject(_unitButtons[id].gameObject);
                }
            }
        }
    }
}

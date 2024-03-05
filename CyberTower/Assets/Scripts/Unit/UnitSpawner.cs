using System.Collections.Generic;
using InstantGamesBridge;
using UnityEngine;
using UnityEngine.EventSystems;
using DeviceType = InstantGamesBridge.Modules.Device.DeviceType;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private List<Unit> _units;
    [SerializeField] private List<UnitSpawnButton> _unitButtons;
    [SerializeField] private Transform _leftSpawnZone, _rightSpawnZone;
    [SerializeField] private SpriteRenderer _spawnedUnit;
    [SerializeField] private Color _canUnitColor, _cantUnitColor;
    private Unit _currentUnit;
    private Camera _camera;
    private GameManager _gameManager;
    private MoneyManager _moneyManager;
    private List<string> _numbers = new() { "1", "2", "3", "4", "5", "6" };
    private Vector2 _spawnPosition;
    private bool _isMobile;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnLoadLevel += EnableButtons;
        _gameManager.OnPlayWave += () => SetUnit(null);
        _moneyManager = FindObjectOfType<MoneyManager>();
        _camera = Camera.main;
        _isMobile = Bridge.device.type == DeviceType.Mobile || 
                    Bridge.device.type == DeviceType.Tablet;
    }

    private void EnableButtons()
    {
        if (_gameManager.CurrentLevel < 2)
        {
            _unitButtons[0].gameObject.SetActive(true);
            _unitButtons[0].unit = _units[0];
            _unitButtons[1].gameObject.SetActive(true);
            _unitButtons[1].unit = _units[1];
        }
        else
        {
            for (int item = 0; item < _unitButtons.Count; item++)
            {
                if (_gameManager.CurrentLevel + 1 > item)
                {
                    _unitButtons[item].unit = _units[item];
                    _unitButtons[item].gameObject.SetActive(true);
                }
            }
        }
    }

    public void SetUnit(Unit unit)
    {
        _currentUnit = unit;
        if (unit != null) 
            _spawnedUnit.sprite = unit.avatar;
        _spawnedUnit.gameObject.SetActive(unit != null);
    }

    public void Spawn(Vector2 position)
    {
        if (_currentUnit == null && _currentUnit.price > _moneyManager.money) return;
        _spawnPosition = new Vector2(position.x, _currentUnit.spawnY);
        Unit newUnit = Instantiate(_currentUnit, _spawnPosition, Quaternion.identity);
        _gameManager.units.Add(newUnit.gameObject);
        _moneyManager.BuyUnit(newUnit);
        _gameManager.BuySouls(newUnit.soul);
        _currentUnit = null;
        EventSystem.current.SetSelectedGameObject(null);
        _spawnedUnit.gameObject.SetActive(false);
    }

    private void SetUnit(int unitId)
    {
        _currentUnit = _units[unitId];
        _spawnedUnit.sprite = _currentUnit.avatar;
        _spawnedUnit.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_isMobile == false)
        {

            if (_currentUnit != null && !EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                SetSpawnedUnitPosition(mousePosition);
                if(Input.GetMouseButtonDown(0) && CheckZone(mousePosition))
                    Spawn(mousePosition);
            }

            if (Input.anyKey)
            {
                if (_numbers.Contains(Input.inputString))
                {
                    int id = int.Parse(Input.inputString) - 1;
                    if (_gameManager.CurrentLevel >= id && _moneyManager.CheckUnitPrice(_units[id]) || _gameManager.CheckSouls(_units[id]))
                    {
                        SetUnit(id);
                        EventSystem.current.SetSelectedGameObject(_unitButtons[id].gameObject);
                    }
                }
            }
        }
    }

    public void SetSpawnedUnitPosition(Vector2 position)
    {
        _spawnedUnit.color = CheckZone(position) ? _canUnitColor : _cantUnitColor;
        var spawnedUnitPosition = _spawnedUnit.transform.position;
        spawnedUnitPosition.x = position.x;
        _spawnedUnit.transform.position = spawnedUnitPosition;
    }

    public bool CheckZone(Vector2 position) => 
        position.x > _leftSpawnZone.position.x && position.x < _rightSpawnZone.position.x;
}

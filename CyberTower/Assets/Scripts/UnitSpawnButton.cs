using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitSpawnButton : 
    MonoBehaviour, IDragHandler,
    IEndDragHandler, IBeginDragHandler,
    ISelectHandler, IDeselectHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _moveTime;
    [SerializeField] private float _scaleAmount;
    [HideInInspector] public Unit unit;
    private Canvas _canvas;
    private Vector2 _startPosition;
    private Vector2 _startScale;
    private UnitSpawner _unitSpawner;
    private RectTransform _transform;
    private Coroutine _moveCoroutine;
    private Camera _camera;
    private GameManager _gameManager;
    private MoneyManager _moneyManager;
    private bool _canMove;
    
    private void Start()
    {
        _camera = Camera.main;
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnWaitWave += EnableOrDisable;
        _moneyManager = FindObjectOfType<MoneyManager>();
        _moneyManager.OnChangeMoney += EnableOrDisable;
        _canvas = GetComponentInParent<Canvas>();
        _unitSpawner = FindObjectOfType<UnitSpawner>();
        _transform = GetComponent<RectTransform>();
        _startScale = transform.localScale;
        EnableOrDisable();
    }
    
    private IEnumerator MoveButton(bool isMoveNow)
    {
        float elapsedTime = 0f;
        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.deltaTime;
            var endScale = isMoveNow ? _startScale * _scaleAmount : _startScale;
            Vector2 lerpScale = Vector2.Lerp(transform.localScale, endScale, elapsedTime / _moveTime);
            transform.localScale = lerpScale;
            yield return null;
        }
    }

    private void EnableOrDisable()
    {
        if (unit != null && _moneyManager.CheckUnitPrice(unit) == false)
        {
            GetComponent<Image>().color = Color.gray;
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (_moneyManager.CheckUnitPrice(unit))
        {
            Vector2 worldPosition = _camera.ScreenToWorldPoint(_transform.position);
            _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
            _unitSpawner.SetSpawnedUnitPosition(worldPosition);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_moneyManager.CheckUnitPrice(unit))
        {
            Vector2 worldPosition = _camera.ScreenToWorldPoint(_transform.position);
            if (_unitSpawner.CheckZone(worldPosition))
            {
                _unitSpawner.Spawn(worldPosition);
            }
            else
            {
                _unitSpawner.SetUnit(null);
            }

            _transform.anchoredPosition = _startPosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_moneyManager.CheckUnitPrice(unit))
        {
            _unitSpawner.SetUnit(unit);
            _startPosition = _transform.anchoredPosition;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);
        _moveCoroutine = StartCoroutine(MoveButton(true));
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if(_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);
        _moveCoroutine = StartCoroutine(MoveButton(false));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_moneyManager.CheckUnitPrice(unit))
            eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_moneyManager.CheckUnitPrice(unit))
            eventData.selectedObject = null;
    }
}
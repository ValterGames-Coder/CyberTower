using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

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
    
    private void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
        _unitSpawner = FindObjectOfType<UnitSpawner>();
        _transform = GetComponent<RectTransform>();
        _startScale = transform.localScale;
    }
    
    private IEnumerator Move(bool isMoveNow)
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
    
    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _unitSpawner.SetUnit(unit);
        _unitSpawner.Spawn(transform);
        _transform.anchoredPosition = _startPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _unitSpawner.SetUnit(null);
        Debug.Log(_transform.anchoredPosition);
        _startPosition = _transform.anchoredPosition;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);
        _moveCoroutine = StartCoroutine(Move(true));
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if(_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);
        _moveCoroutine = StartCoroutine(Move(false));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }
}
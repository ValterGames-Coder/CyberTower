using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _moveTime;
    [SerializeField] private Vector3 _offset;
    private Vector3 _target;
    private Vector3 _startPosition;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _startPosition = transform.position;
    }

    private void LateUpdate()
    {
        _target = _gameManager.State == GameState.Play ? _gameManager.Tower.position + _offset : _startPosition;
        Vector3 transformPosition = transform.position;
        transformPosition.x = Mathf.Lerp(transformPosition.x, _target.x, _moveTime * Time.deltaTime);
        transform.position = transformPosition;
    }
}
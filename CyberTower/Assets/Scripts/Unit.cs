using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Unit : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 _stoppedDistance = new (4f, 12f);
    private float _randomStoppedDistance;
    
    [SerializeField] private Animator _animator;

    private GameManager _game;

    private void Start()
    {
        _game = FindObjectOfType<GameManager>();
        _randomStoppedDistance = Random.Range(_stoppedDistance.x, _stoppedDistance.y);
    }

    private void FixedUpdate()
    {
        if (_game.tower.position.x - transform.position.x > _randomStoppedDistance)
        {
            Vector3 position = transform.position;
            Vector2 target = new Vector2(_game.tower.position.x, position.y);
            position = Vector3.MoveTowards(position, target , _speed * Time.deltaTime);
            transform.position = position;
            // Анимация
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }
}

using UnityEngine;

public class CanvasAnimator : MonoBehaviour
{
    [SerializeField] private Animator _canvasAnimator;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnPlayWave += () => _canvasAnimator.SetTrigger("Play");
        _gameManager.OnWaitWave += () => _canvasAnimator.SetTrigger("Wait");
    }
}
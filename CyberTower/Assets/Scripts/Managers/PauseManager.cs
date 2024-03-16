using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPause;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        _isPause = !_isPause;
        Time.timeScale = _isPause ? 0 : 1;
    }
}
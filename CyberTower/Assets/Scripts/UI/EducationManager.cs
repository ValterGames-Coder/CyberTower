using System.Collections.Generic;
using InstantGamesBridge;
using UnityEngine;

public class EducationManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _frames;
    [SerializeField] private GameObject _backButton, _nextButton;
    private int _currentFrame;

    private void Awake()
    {
        Bridge.storage.Get("Education", OnComplete);
    }

    private void OnComplete(bool success, string data)
    {
        if (success)
        {
            if (data != null)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ChangeFrame(int change)
    {
        //_backButton.SetActive(_currentFrame + change >= 1);
        if (_currentFrame + change == _frames.Count)
        {
            Bridge.storage.Set("Education", "true");
            gameObject.SetActive(false);
        }
        else
        {
            _frames[_currentFrame].SetActive(false);
            _frames[_currentFrame + change].SetActive(true);
            _currentFrame += change;
        }
    }
}
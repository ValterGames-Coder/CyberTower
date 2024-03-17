using System.Collections.Generic;
using UnityEngine;

public class EducationManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _frames;
    [SerializeField] private GameObject _backButton, _nextButton;
    private int _currentFrame;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("Education", 0) == 1)
            gameObject.SetActive(false);
    }

    public void ChangeFrame(int change)
    {
        //_backButton.SetActive(_currentFrame + change >= 1);
        if (_currentFrame + change == _frames.Count)
        {
            PlayerPrefs.SetInt("Education", 1);
            PlayerPrefs.Save();
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
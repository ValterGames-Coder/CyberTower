using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private GameObject _panelIfWin;
    [SerializeField] private TMP_Text _textIfWin;
    [SerializeField] private Image _imageIfWin;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<string> _names;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnWin += GameManagerOnOnWin;
        _gameManager.OnLose += GameManagerOnOnLose;
    }

    private void GameManagerOnOnLose()
    {
        _panel.SetActive(true);
        _panelLose.SetActive(true);
    }

    private void GameManagerOnOnWin()
    {
        _panel.SetActive(true);
        if(_gameManager.CurrentLevel != 0)
            _panelWin.SetActive(true);
        if (_gameManager.CurrentLevel < 5)
        {
            _panelIfWin.SetActive(true);
            _imageIfWin.sprite = _sprites[_gameManager.CurrentLevel + 1];
            _textIfWin.text = $"Получен новый боец:\n{_names[_gameManager.CurrentLevel+1]}";
        }

    }
}
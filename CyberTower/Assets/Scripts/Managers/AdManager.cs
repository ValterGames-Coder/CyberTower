using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] private GameObject _secondLifePanel;
    private LevelManager _levelManager;
    private GameManager _gameManager;
    private GameUIManager _gameUIManager;
    private MoneyManager _moneyManager;

    private void OnEnable()
    {
        //YandexGame.RewardVideoEvent += RewardVideoEvent;
    }

    private void RewardVideoEvent(int id)
    {
        if (id == 1)
        {
            _secondLifePanel.SetActive(false);
            _levelManager.SecondLife();
            _gameManager.SecondLife();
            _gameUIManager.SecondLife();
            _moneyManager.SecondLife();
        }
    }

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _gameUIManager = FindObjectOfType<GameUIManager>();
        _moneyManager = FindObjectOfType<MoneyManager>();
        //YandexGame.FullscreenShow();
    }

    public void ShowRewardedAd()
    {
        //YandexGame.RewVideoShow(1);
    }
}
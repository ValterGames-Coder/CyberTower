using UnityEngine;
using YG;

public class AdManager : MonoBehaviour
{
    [SerializeField] private GameObject _secondLifePanel;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += RewardVideoEvent;
    }

    private void RewardVideoEvent(int id)
    {
        if (id == 1)
        {
            _secondLifePanel.SetActive(false);
            FindObjectOfType<LevelManager>().SecondLife();
            FindObjectOfType<GameManager>().SecondLife();
            FindObjectOfType<GameUIManager>().SecondLife();
            FindObjectOfType<MoneyManager>().SecondLife();
        }
    }

    private void Start()
    {
        YandexGame.FullscreenShow();
    }

    public void ShowRewardedAd()
    {
        YandexGame.RewVideoShow(1);
    }
}
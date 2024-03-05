using InstantGamesBridge;
using InstantGamesBridge.Modules.Advertisement;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] private GameObject _adBanner;
    [SerializeField] private GameObject _secondLifePanel;
    private MusicManager _music;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _music = FindObjectOfType<MusicManager>();
        _gameManager.OnWin += GameManagerOnEnd;
        _gameManager.OnLose += GameManagerOnEnd;
        Bridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
        Bridge.advertisement.rewardedStateChanged += OnRewardedStateChanged;
        Debug.Log("Ad Init");
    }

    private void OnRewardedStateChanged(RewardedState obj)
    {
        Debug.Log(obj);
        switch (obj)
        {
            case RewardedState.Loading:
                _adBanner.SetActive(true);
                _music.GetComponent<AudioSource>().volume = 0;
                break;
            case RewardedState.Closed:
                _adBanner.SetActive(false);
                _music.GetComponent<AudioSource>().volume = 1;
                break;
            case RewardedState.Failed:
                _adBanner.SetActive(false);
                _music.GetComponent<AudioSource>().volume = 1;
                break;
            case RewardedState.Rewarded:
                _adBanner.SetActive(false);
                _music.GetComponent<AudioSource>().volume = 1;
                SecondLife();
                break;
        }
    }

    private void SecondLife()
    {
        _secondLifePanel.SetActive(false);
        FindObjectOfType<Tower>().GetComponent<Health>().SecondLife();
    }

    private void OnInterstitialStateChanged(InterstitialState obj)
    {
        Debug.Log(obj);
        switch (obj)
        {
            case InterstitialState.Loading:
                _adBanner.SetActive(true);
                break;
            case InterstitialState.Closed:
                _adBanner.SetActive(false);
                break;
            case InterstitialState.Failed:
                _adBanner.SetActive(false);
                break;
        }
    }

    private void GameManagerOnEnd()
    {
        Bridge.advertisement.ShowInterstitial();
        Debug.Log("Show Ad");
    }

    public void ShowRewardedAd()
    {
        Bridge.advertisement.ShowRewarded();
        Debug.Log("Show Ad");
    }
}
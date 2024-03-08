using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Random = UnityEngine.Random;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    
    [Serializable]
    public class Clips
    {
        public string Name;
        public List<AudioClip> tracks = new List<AudioClip>();
    }
    [SerializeField] private List<Clips> _clips;
    //private AudioListener _audioListener;
    [SerializeField] private float _timeAppearance;
    [SerializeField] private Toggle _musicToggle;
    private AudioSource _audio;
    private int index;
    private int _musicVolume, _musicFocus, _musicPause;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        
        Destroy(this.gameObject);
    }
    
    public void SetMusicVolume()
    {
        //_audioListener.enabled = _musicToggle.isOn;
        _musicVolume = _musicToggle.isOn ? 1 : 0;
        YandexGame.savesData.music = _musicToggle.isOn ? 1 : 0;
        YandexGame.SaveProgress();
    }
    
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        //_audioListener = FindObjectOfType<AudioListener>();
        SceneManager.activeSceneChanged += SceneManagerOnactiveSceneChanged;
        if (YandexGame.SDKEnabled)
        {
            if (_musicToggle != null)
                _musicToggle.isOn = YandexGame.savesData.music == 1;
            _musicVolume = YandexGame.savesData.music;
        }
    }

    private void SceneManagerOnactiveSceneChanged(Scene arg0, Scene arg1)
    {
        index = arg1.buildIndex;
        _audio.Stop();
    }

    private void Update()
    {
        if (!_audio.isPlaying)
        {
            int clipIndex = Random.Range(0, _clips[index].tracks.Count);
            _audio.clip = _clips[index].tracks[clipIndex];
            _audio.Play();
        }
        _audio.volume = _musicVolume * _musicFocus * _musicPause;
    }

    private void OnMusicLoadComplete(bool success, string data)
    {
        if (success)
        {
            if (data != null)
            { 
                if(_musicToggle != null)
                    _musicToggle.isOn = data == "true";
                _musicVolume = data == "true" ? 1 : 0;
            }
            else
            {
                _musicVolume = 1;
            }
        }
        else
        {
            _musicVolume = 1;
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        _musicPause = pauseStatus ? 0 : 1;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        _musicFocus = hasFocus ? 1 : 0;
    }
}

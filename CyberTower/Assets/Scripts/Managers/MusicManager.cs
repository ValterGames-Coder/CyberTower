using System;
using System.Collections.Generic;
using InstantGamesBridge;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    private AudioListener _audioListener;
    [SerializeField] private float _timeAppearance;
    [SerializeField] private Toggle _musicToggle;
    private AudioSource _audio;
    private int index;
    
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
        _audioListener.enabled = _musicToggle.isOn;
        Bridge.storage.Set("Music", _musicToggle.isOn ? "true" : "false");
    }
    
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audioListener = FindObjectOfType<AudioListener>();
        SceneManager.activeSceneChanged += SceneManagerOnactiveSceneChanged;
        Bridge.storage.Get("Music", OnMusicLoadComplete);
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
    }

    private void OnMusicLoadComplete(bool success, string data)
    {
        if (success)
        {
            if (data != null)
            { 
                if(_musicToggle != null)
                    _musicToggle.isOn = data == "true";
                _audioListener.enabled = data == "true";
            }
            else
            {
                _audioListener.enabled = true;
            }
        }
        else
        {
            _audioListener.enabled = true;
        }
    }
}

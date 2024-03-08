using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using YG;

public class Settings : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _volume;
    [SerializeField] private Toggle _volumeToggle;
    private bool _isOn;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            _isOn = YandexGame.savesData.renderVolume;
            _camera.GetUniversalAdditionalCameraData().renderPostProcessing = _isOn;
            _volume.SetActive(_isOn);
            if (_volumeToggle != null) _volumeToggle.isOn = _isOn;
        }
    }

    public void OpenURL(string url) => Application.OpenURL(url);

    public void SetRenderVolume()
    {
        YandexGame.savesData.renderVolume = _volumeToggle.isOn;
        YandexGame.SaveProgress();
        _isOn = _volumeToggle.isOn;
        _camera.GetUniversalAdditionalCameraData().renderPostProcessing = _isOn;
        _volume.SetActive(_isOn);
        print(_isOn);
    }
}
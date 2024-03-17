using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _volume;
    [SerializeField] private Toggle _volumeToggle;
    private bool _isOn;

    private void Start()
    {
        _isOn = PlayerPrefs.GetInt("RenderVolume",  1) == 1;
        _camera.GetUniversalAdditionalCameraData().renderPostProcessing = _isOn;
        _volume.SetActive(_isOn);
        if (_volumeToggle != null) _volumeToggle.isOn = _isOn;
    }

    public void OpenURL(string url) => Application.OpenURL(url);

    public void SetRenderVolume()
    {
        PlayerPrefs.SetInt("RenderVolume",_volumeToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
        _isOn = _volumeToggle.isOn;
        _camera.GetUniversalAdditionalCameraData().renderPostProcessing = _isOn;
        _volume.SetActive(_isOn);
        print(_isOn);
    }
}
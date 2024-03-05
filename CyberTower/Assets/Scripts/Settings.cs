using InstantGamesBridge;
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
        Bridge.storage.Get("RenderVolume", OnComplete);
    }

    public void OpenURL(string url) => Application.OpenURL(url);

    private void OnComplete(bool success, string data)
    {
        if (success)
        {
            if (data != null)
            {
                _isOn = data == "true";
                _camera.GetUniversalAdditionalCameraData().renderPostProcessing = _isOn;
                _volume.SetActive(_isOn);
                if(_volumeToggle != null) _volumeToggle.isOn = _isOn;
                Debug.Log(data);
            }
            else
            {
                _isOn = true;
            }
        }
        else
        {
            _isOn = true;
        }
    }

    public void SetRenderVolume()
    {
        Bridge.storage.Set("RenderVolume", _volumeToggle.isOn ? "true" : "false");
        _isOn = _volumeToggle.isOn;
        _camera.GetUniversalAdditionalCameraData().renderPostProcessing = _isOn;
        _volume.SetActive(_isOn);
        print(_isOn);
    }
}
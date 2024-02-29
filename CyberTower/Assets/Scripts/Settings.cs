using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _volume;
    [SerializeField] private Toggle _volumeToggle;

    private void Start()
    {
        if (PlayerPrefs.HasKey("RenderVolume"))
        {
            _camera.GetUniversalAdditionalCameraData().renderPostProcessing = PlayerPrefs.GetInt("RenderVolume") == 0;
            _volume.SetActive(PlayerPrefs.GetInt("RenderVolume") == 0);
            print(PlayerPrefs.GetInt("RenderVolume") );
        }
        if(_volumeToggle != null) _volumeToggle.isOn = PlayerPrefs.GetInt("RenderVolume") == 0;
    }

    public void SetRenderVolume()
    {
        PlayerPrefs.SetInt("RenderVolume", PlayerPrefs.GetInt("RenderVolume") == 0 ? 1 : 0);
        PlayerPrefs.Save();
        _camera.GetUniversalAdditionalCameraData().renderPostProcessing = PlayerPrefs.GetInt("RenderVolume") == 0;
        _volume.SetActive(PlayerPrefs.GetInt("RenderVolume") == 0);
        print(PlayerPrefs.GetInt("RenderVolume") );
    }
}
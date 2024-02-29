using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    public void MoveToScene(int sceneId) => SceneManager.LoadScene(sceneId);

    public void PlayHistory(int sceneId)
    {
        if (PlayerPrefs.HasKey("History"))
        {
            SceneManager.LoadScene(sceneId);
        }
        else
        {
            _director.Play();
            PlayerPrefs.SetInt("History", 1);
        }
    }
}
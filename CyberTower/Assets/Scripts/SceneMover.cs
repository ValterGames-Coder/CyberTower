using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    public void MoveToScene(int sceneId) => SceneManager.LoadScene(sceneId);

    public void PlayHistory(int sceneId)
    {

        if(PlayerPrefs.GetInt("History", 0) != 0)
            SceneManager.LoadScene(PlayerPrefs.GetInt("History"));
        else
        {
            _director.Play();
            PlayerPrefs.SetInt("History", 1);
            PlayerPrefs.Save();
        }
    }

    public void TheEnd()
    {
        PlayerPrefs.SetInt("History", 0);
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.Save();
    }
}
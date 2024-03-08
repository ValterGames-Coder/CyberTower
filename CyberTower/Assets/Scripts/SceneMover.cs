using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using YG;

public class SceneMover : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    public void MoveToScene(int sceneId) => SceneManager.LoadScene(sceneId);

    public void PlayHistory(int sceneId)
    {
        if (YandexGame.SDKEnabled)
        {
            if(YandexGame.savesData.history != 0)
                SceneManager.LoadScene(YandexGame.savesData.history);
            else
            {
                _director.Play();
                YandexGame.savesData.history = 1;
                YandexGame.SaveProgress();
            }
        }
    }

    public void TheEnd()
    {
        YandexGame.savesData.history = 0;
        YandexGame.savesData.level = 0;
        YandexGame.SaveProgress();
    }
}
using System;
using System.Collections.Generic;
using InstantGamesBridge;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    public void MoveToScene(int sceneId) => SceneManager.LoadScene(sceneId);

    public void PlayHistory(int sceneId)
    {
        Bridge.storage.Get("History", OnComplete);
    }

    private void OnComplete(bool success, string data)
    {
        if (success)
        {
            if (data != null)
            {
                SceneManager.LoadScene(Int32.Parse(data));
                Debug.Log(data);
            }
            else
            {
                _director.Play();
                Bridge.storage.Set("History", 1);
            }
        }
        else
        {
            Bridge.storage.Set("History", 1);
        }
    }

    public void TheEnd()
    {
        List<string> keys = new List<string>() { "History", "Level" };
        Bridge.storage.Delete(keys);
    }
}
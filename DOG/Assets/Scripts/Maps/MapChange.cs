using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChange : MonoBehaviour
{
    public int sceneID = 1;
    CanvasFadeInOut fadeInOut;

    private void Start()
    {
        fadeInOut = FindObjectOfType<CanvasFadeInOut>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("들어옴");
        fadeInOut.OnFadeOutEnd = SceneLoad;
        fadeInOut.StartFadeOut();
    }

    void SceneLoad()
    {
        LoadingSceneManager.LoadScene(sceneID);
    }
}

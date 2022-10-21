using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float time;
    Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Invoke("LoadMainMenu", time);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    
}

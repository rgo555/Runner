using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour
{
    public static InGameMenuManager Instance;

    public GameObject restartButton;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ReloadLevel()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(scene.buildIndex);
        Global.vidas = 3;
    }

    public void LoadMenu()
    {
        GameManager.Instance.LoadMainMenu();
        SoundManager.Instance.SeleccionAudio(0);
    }
}

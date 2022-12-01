using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;

    public bool isPlaying = false;
    Scene scene;


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

        DontDestroyOnLoad(this);
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelFinisher()
    {
        Global.nivelMaximo ++;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
        AudioManager.Instance.CuentaRegresivaSound();
        SoundManager.Instance.SeleccionAudio(1);
        //uwu
    }

    public void Choque()
    {
        Global.vidas--;
        AudioManager.Instance.DeathSound();
        
        if(Global.vidas == 0)
        {
            Debug.Log("Dead");
            isPlaying = false;
            InGameMenuManager.Instance.restartButton.SetActive(true);
        }   
    }

    public void AddCoins()
    {
        Global.numberCoins += 1;
        AudioManager.Instance.CoinSFX();
    }

}

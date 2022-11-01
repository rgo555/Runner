using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    private Animator animCuentaAtras;
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
    /*
        En el movimiento poner un if para que mientras se ejecuta la cuenta atrás el personaje no se mueva
    */

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
        AudioManager.Instance.CuentaRegresivaSound();
    }

    public void LevelFinisher()
    {
        Global.nivelMaximo ++;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
        AudioManager.Instance.CuentaRegresivaSound();
        //uwu
    }

}

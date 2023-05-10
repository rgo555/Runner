using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Titulo;
    public GameObject BotonesMenu;
    public GameObject OptionsMenu;
    public GameObject PlayMenu;

    public void OpenOptions()
    {
        Titulo.SetActive(false);
        BotonesMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void OpenLevels()
    {
        Titulo.SetActive(false);
        BotonesMenu.SetActive(false);
        PlayMenu.SetActive(true);
    }

    public void LoadScene()
    {
        Global.nivelMaximo = PlayerPrefs.GetInt("LevelMax");
        SceneManager.LoadScene(Global.nivelMaximo);

    }

    public void StartGame()
    {
        //GameManager.Instance.LevelFinisher();
        Global.nivelMaximo = 3;
        SceneManager.LoadScene(Global.nivelMaximo);
        PlayerPrefs.SetInt("LevelMax",Global.nivelMaximo);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

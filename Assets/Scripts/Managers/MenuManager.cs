using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Titulo;
    public GameObject BotonesMenu;
    public GameObject OptionsMenu;

    public void OpenOptions()
    {
        Titulo.SetActive(false);
        BotonesMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("EscenaLorenaNueva");
    }
}

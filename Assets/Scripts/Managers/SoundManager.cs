using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]private AudioClip[] audios;

    private AudioSource controlAudio;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        controlAudio = GetComponent<AudioSource>();

        SeleccionAudio(0);
    }

    public void SeleccionAudio (int indice)
    {
        controlAudio.clip = audios[indice];
        controlAudio.Play(); 
    }
}

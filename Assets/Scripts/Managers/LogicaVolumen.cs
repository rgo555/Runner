using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public GameObject imagenMute;
    [SerializeField]private AudioSource audioSource;
    private bool isMuted = false;

    //Bool para saber si el audiosource que buscamos es el de SFX
    [SerializeField]private bool SFX;
    

    // Start is called before the first frame update
    void Awake()
    {
        //Cargamos el volumen guardado de la anterior partida
        sliderValue =  PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        slider.value = sliderValue;

        if(SFX)
        {
            audioSource = GameObject.FindObjectOfType<SFXManager>().GetComponent<AudioSource>();
        }
        else
        {
            audioSource = GameObject.FindObjectOfType<SoundManager>().GetComponent<AudioSource>();
        }

        //Le asignamos al volumen guardado al audiosource
        audioSource.volume = sliderValue;
        //Asignar funcion al slider
        slider.onValueChanged.AddListener(delegate {ChangeSlider();});

        //Si habiamos muteado el juego que al volver a iniciarlo siga muteado
        if(PlayerPrefs.GetString("MuteSFX") == "true" && SFX || PlayerPrefs.GetString("MuteMusic") == "true" && !SFX)
        {
            RevisarSiEstoyMute();
        }


    }

    public void ChangeSlider()
    {
        sliderValue = slider.value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        audioSource.volume = sliderValue;
    }

    public void RevisarSiEstoyMute()
    {
        if(!isMuted)
        {
            audioSource.mute = true;
            isMuted = true;
            imagenMute.SetActive(true);

            //Guardamos que hemos muteado el sonido de los SFX o la musica
            if(SFX)
            {
                PlayerPrefs.SetString("MuteSFX", "true");
            }
            else
            {
                 PlayerPrefs.SetString("MuteMusic", "true");
            }
        }
        else
        {
            audioSource.mute = false;
            isMuted = false;
            imagenMute.SetActive(false);

            //Guardamos que hemos desmuteado el sonido de los SFX o la musica
            if(SFX)
            {
                PlayerPrefs.SetString("MuteSFX", "false");
            }
            else
            {
                 PlayerPrefs.SetString("MuteMusic", "false");
            }
        }

    }
}

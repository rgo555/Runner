using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public GameObject imagenMute;
    private AudioSource audioSource;
    private bool isMuted = false;
    

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void ChangeSlider()
    {
        sliderValue = slider.value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        audioSource.volume = slider.value;
    }

    public void RevisarSiEstoyMute()
    {
       /* if (sliderValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }*/

        if(!isMuted)
        {
            audioSource.mute = true;
            isMuted = true;
            imagenMute.SetActive(true);
        }
        else
        {
            audioSource.mute = false;
            isMuted = false;
            imagenMute.SetActive(false);
        }

    }
}

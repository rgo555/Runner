using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSourceSFX;
    public AudioClip cuentaRegresiva;
    public static AudioManager Instance;

   
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
        _audioSourceSFX = GetComponent<AudioSource>();
        
    }


    public void CuentaRegresivaSound()
    {
        _audioSourceSFX.PlayOneShot(cuentaRegresiva);
    }
}

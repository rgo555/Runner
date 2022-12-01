using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private AudioSource _audioSourceSFX;
    
    public AudioClip cuentaRegresiva;
    public AudioClip deathSFX;
    public AudioClip coinSFX;

   
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
        _audioSourceSFX = GetComponent<AudioSource>();
        
    }


    public void CuentaRegresivaSound()
    {
        _audioSourceSFX.PlayOneShot(cuentaRegresiva);
    }

    public void DeathSound()
    {
        _audioSourceSFX.PlayOneShot(deathSFX);
    }

    public void CoinSFX()
    {
        _audioSourceSFX.PlayOneShot(coinSFX);
    }
}

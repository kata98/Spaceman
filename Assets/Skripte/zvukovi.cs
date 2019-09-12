using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zvukovi : MonoBehaviour
{
    
    public AudioClip novcicZvuk;
    public AudioClip pesma;

    public AudioSource audios;

    void Start()
    {
        audios.volume = PlayerPrefs.GetInt("zvuk", 1);
        audios.PlayOneShot(pesma, 1f);
    }

    void zvuk_novcic()
    {
        audios.PlayOneShot(novcicZvuk, 1f);
    }

}

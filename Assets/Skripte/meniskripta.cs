using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class meniskripta : MonoBehaviour
{
    public AudioClip pesma;
    public Button zvukdugme;
    public Sprite s1, s2;
    bool z = true;

    public AudioSource auS;

    [SerializeField]
    GameObject Pauza = default;


    [SerializeField]
    GameObject Odpauziraj = default;

    bool pauzirano;

    void Start()
    {
        auS.PlayOneShot(pesma, 1f);
    }

    public void quitDugme()
    {
        Application.Quit();
    }

    public void playDugme()
    {
        SceneManager.LoadScene(1);
    }

    public void Pauziraj()
    {
        if (!pauzirano)
        {
            Pauza.SetActive(false);
            Odpauziraj.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Pokreni()
    {
        Pauza.SetActive(true);
        Odpauziraj.SetActive(false);
        Time.timeScale = 1f;
    }

    public void iskljuciZvuk()
    {
        z = !z;
        if (z)
        {
            zvukdugme.GetComponent<Image>().sprite = s1;
            auS.volume = 1;
            PlayerPrefs.SetInt("zvuk", 1);
        }
        else
        {
            zvukdugme.GetComponent<Image>().sprite = s2;
            auS.volume = 0;
            PlayerPrefs.SetInt("zvuk", 0);
        }
    }
}

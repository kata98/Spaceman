using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class novcici_zivoti : MonoBehaviour
{
    [SerializeField]
    Text brojPoena;

    int poeni = 0;

    void Start()
    {
        brojPoena.text = "0 / 3";
    }

    void proveri_novcice(GameObject novcic)
    {
        Destroy(novcic);
        SendMessageUpwards("zvuk_novcic");
        poeni++;
        brojPoena.text = poeni + " / 3";

        if(poeni == 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pomeranje : MonoBehaviour
{
    private Rigidbody2D rb;

    public Animator animator;
    public int brzina = 0;

    [SerializeField]
    GameObject Restart = default;

    [SerializeField]
    GameObject Pobeda = default;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * 15);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-2 * Time.deltaTime, 0, 0);
            animator.SetInteger("brzina", -1);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            animator.SetInteger("brzina", 0);


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(2 * Time.deltaTime, 0, 0);
            animator.SetInteger("brzina", 1);
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow))
            animator.SetInteger("brzina", 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "novcici")
        {
            SendMessageUpwards("proveri_novcice", col.gameObject);
        }

        if (col.gameObject.tag == "desno")
        {
            Pobeda.SetActive(true);
            StartCoroutine(kraj());

        }

        if (col.gameObject.tag == "granica")
        {
            Restart.SetActive(true);
            StartCoroutine(resetuj_nivo());
        }


    }

    IEnumerator kraj()
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(0);
    }

    IEnumerator resetuj_nivo()
    {
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          
    }
}

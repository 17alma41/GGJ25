using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    Animator anim;
    public GameObject t1;
    public GameObject t2;
    bool txt;
    public static bool tact;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("crout", false);
        txt = false;
        t1.SetActive(false);
        t2.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.cr == true)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            tact = false;
            txt = false;
            anim.SetBool("crout", true);
        }
        else if (txt == false)
        {
            Invoke("text", 1f);
            txt = true;
        }
    }
    void text()
    {
        t1.SetActive(true);
        t2.SetActive(true);
        tact = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource auso;
    public GameObject fadein;
    public AudioClip click;
    public GameObject panelcreditos;
    public static bool cr;
    bool cract;
    // Start is called before the first frame update
    void Start()
    {
        auso = GetComponent<AudioSource>();
        Invoke("fade", 1f);
        panelcreditos.SetActive(false);
        cr = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && cr == false && cract == true && Creditos.tact == true)
        {
            cr = true;
            Invoke("outcredit", 1f);
            cract = false;

        }
    }
    public void Play ()
    {
        //print("empiezas");
        auso.PlayOneShot(click);
        SceneManager.LoadScene("SampleScene");


    }
    public void Exit()
    {
        //print("terminas");
        auso.PlayOneShot(click);
        Application.Quit();

    }
    public void fade()
    {
        fadein.SetActive (false);
    }
    public void creditos()
    { 
        panelcreditos.SetActive (true);
        auso.PlayOneShot(click);
        cract = true;
        
    }
    public void outcredit()
    {
        cr = false;
        panelcreditos.SetActive(false);
    }
}

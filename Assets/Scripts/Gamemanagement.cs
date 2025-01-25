using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanagement : MonoBehaviour
{
    AudioSource auso;
    public GameObject fadein;
    public AudioClip click;
    public GameObject panelcreditos;
    public static bool cr;
    bool cract;
    public GameObject panelpausa;
    bool pausado;
    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        auso = GetComponent<AudioSource>();
        Invoke("fade", 1f);
        panelcreditos.SetActive(false);
        cr = false;
        Time.timeScale = 1f;
    }

    private void Awake()
    {
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado == false)
            {
                panelpausa.SetActive(true);
                Time.timeScale = 0f;
                pausado = true;
                
            }
            else
            {
                panelpausa.SetActive(false);
                Time.timeScale = 1f;
                pausado=false;
            }


        }
    }
    public void Play()
    {
        //print("empiezas");
        auso.PlayOneShot(click);
        SceneManager.LoadScene("MainScene");


    }
    public void Home()
    {
   print("empiezas");
        auso.PlayOneShot(click);
        SceneManager.LoadScene("Inicio");


    }
    public void Restart()
    {
        //print("empiezas");
        auso.PlayOneShot(click);
        panelpausa.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Exit()
    {
        //print("terminas");
        auso.PlayOneShot(click);
        Application.Quit();

    }
    public void fade()
    {
        fadein.SetActive(false);
    }
    public void creditos()
    {
        panelcreditos.SetActive(true);
        auso.PlayOneShot(click);
        cract = true;

    }
    public void outcredit()
    {
        cr = false;
        panelcreditos.SetActive(false);
    }
}

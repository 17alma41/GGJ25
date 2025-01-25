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

    LocalRankingManager rankingManager;

    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        rankingManager = GetComponent<LocalRankingManager>();

        auso = GetComponent<AudioSource>();
        Invoke("fade", 1f);
        panelcreditos.SetActive(false);
        cr = false;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

        // Reseteo de BBDD
        if (Input.GetKeyUp(KeyCode.V))
        {

            rankingManager.ResetScores();

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource auso;
    public GameObject fadein;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        auso = GetComponent<AudioSource>();
        Invoke("fade", 1f);
    }

    // Update is called once per frame
    void Update()
    {

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
    public void Onclick()
    {

    }
    public void fade()
    {
        fadein.SetActive (false);
    }
}

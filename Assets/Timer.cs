using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Esta clase tiene que ir dentro del player

    [SerializeField] TextMeshProUGUI text;
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float TimerControl = Time.time - startTime;
        string mins = ((int)TimerControl / 60).ToString("00");
        string segs = (TimerControl % 60).ToString("00");
        string milisegs = ((TimerControl * 100) % 100).ToString("00");

        string TimerString = string.Format("{0}:{1}:{2}", mins, segs, milisegs);

        text.text = TimerString;

    }

    // Penalización
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle")) // NO OLVIDAR: añadir tag "obstacle"
        {
            startTime -= 5f;
        }
    }
}

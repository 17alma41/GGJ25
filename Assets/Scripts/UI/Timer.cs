using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Esta clase tiene que ir dentro del player

    [SerializeField] TextMeshProUGUI timerText;
    float startTime;
    bool isRunning = true;
    float finalTime;


    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float TimerControl = Time.time - startTime;
        string mins = ((int)TimerControl / 60).ToString("00");
        string segs = (TimerControl % 60).ToString("00");
        // string milisegs = ((TimerControl * 100) % 100).ToString("00");

        string TimerString = string.Format("{0}:{1}", mins, segs);

        timerText.text = TimerString;

    }

    // Penalización
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle")) // NO OLVIDAR: añadir tag "obstacle"
        {
            startTime -= 5f;
        }
    }

    public void StopTimer()
    {
        isRunning = false;
        finalTime = Time.time - startTime; // Guarda el tiempo total en segundos
        timerText.text += " (Final)";

        // Guardar el tiempo como puntuación
        SaveFinalTime();
    }

    private void SaveFinalTime()
    {
        // Guardar como puntuación máxima si corresponde
        if (Scoremanager.Instance != null)
        {
            Scoremanager.Instance.AddScore(Mathf.FloorToInt(finalTime)); // Convierte a entero
        }

        // Añadir al ranking local
        if (LocalRankingManager.Instance != null)
        {
            LocalRankingManager.Instance.AddScoreToRanking(Mathf.FloorToInt(finalTime));
        }
    }
}

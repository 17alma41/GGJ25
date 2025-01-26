using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Esta clase tiene que ir dentro del player

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI penaltyText; // Texto para mostrar la penalizaci�n
    [SerializeField] CinemachineImpulseSource impulseSource; // Referencia al generador de impulsos

    float startTime;
    bool isRunning = false; // Cambiado a false para que no inicie autom�ticamente
    float finalTime;

    void Start()
    {
        if (penaltyText != null)
        {
            penaltyText.gameObject.SetActive(false); // Ocultar el texto de penalizaci�n al inicio
        }
    }

    void Update()
    {
        if (isRunning)
        {
            float TimerControl = Time.time - startTime;
            string mins = ((int)TimerControl / 60).ToString("00");
            string segs = (TimerControl % 60).ToString("00");

            string TimerString = string.Format("{0}:{1}", mins, segs);

            timerText.text = TimerString;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time; // Establece el tiempo de inicio
        isRunning = true; // Activa el temporizador
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle")) // NO OLVIDAR: a�adir tag "obstacle"
        {
            ApplyPenalty();
        }
    }

    void ApplyPenalty()
    {
        startTime -= 5f; // Restar 5 segundos al tiempo
        ShowPenaltyText(); // Mostrar el texto de penalizaci�n
        TriggerShake(); // Activar el efecto de shake
    }

    void ShowPenaltyText()
    {
        if (penaltyText != null)
        {
            penaltyText.text = "+5";
            penaltyText.gameObject.SetActive(true);

            // Desactivar el texto despu�s de un tiempo
            StartCoroutine(HidePenaltyText());
        }
    }

    IEnumerator HidePenaltyText()
    {
        yield return new WaitForSeconds(1.5f);
        penaltyText.gameObject.SetActive(false);
    }

    void TriggerShake()
    {
        if (impulseSource != null)
        {
            impulseSource.GenerateImpulse(); // Generar el impulso
        }
    }

    public void StopTimer()
    {
        isRunning = false;
        finalTime = Time.time - startTime; // Guarda el tiempo total en segundos
        //timerText.text += " (Final)";

        // Guardar el tiempo como puntuaci�n
        SaveFinalTime();
    }

    private void SaveFinalTime()
    {
        // Guardar como puntuaci�n m�xima si corresponde
        if (Scoremanager.Instance != null)
        {
            Scoremanager.Instance.AddScore(Mathf.FloorToInt(finalTime)); // Convierte a entero
        }

        // A�adir al ranking local
        if (LocalRankingManager.Instance != null)
        {
            LocalRankingManager.Instance.AddScoreToRanking(Mathf.FloorToInt(finalTime));
        }
    }
}

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
    [SerializeField] TextMeshProUGUI penaltyText; // Texto para mostrar la penalización
    [SerializeField] CinemachineImpulseSource impulseSource; // Referencia al generador de impulsos

    float startTime;
    bool isRunning = true;
    float finalTime;

    void Start()
    {
        startTime = Time.time;

        if (penaltyText != null)
        {
            penaltyText.gameObject.SetActive(false); // Ocultar el texto de penalización al inicio
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle")) // NO OLVIDAR: añadir tag "obstacle"
        {
            ApplyPenalty();
        }
    }

    void ApplyPenalty()
    {
        startTime -= 5f; // Restar 5 segundos al tiempo
        ShowPenaltyText(); // Mostrar el texto de penalización
        TriggerShake(); // Activar el efecto de shake
    }

    void ShowPenaltyText()
    {
        if (penaltyText != null)
        {
            penaltyText.text = "+5 segundos";
            penaltyText.gameObject.SetActive(true);

            // Desactivar el texto después de un tiempo
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

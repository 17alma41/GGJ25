using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        if (Scoremanager.Instance != null)
        {
            float highScore = Scoremanager.Instance.highScore;
            highScoreText.text = $"Mejor Tiempo: {highScore}s";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankingText;

    private void Start()
    {
        DisplayRanking();
    }

    public void DisplayRanking()
    {
        var scores = LocalRankingManager.Instance.GetRanking();
        rankingText.text = "Ranking:\n";

        for (int i = 0; i < scores.Count; i++)
        {
            rankingText.text += $"{i + 1}. {FormatTime(scores[i])}\n";
        }
    }

    private string FormatTime(int timeInSeconds)
    {
        int minutes = timeInSeconds / 60; 
        int seconds = timeInSeconds % 60; 

        return $"{minutes:00}:{seconds:00}"; 
    }
}

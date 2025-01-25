using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankingText;

    void Start()
    {
        DisplayRanking();
    }

    public void DisplayRanking()
    {
        List<int> scores = LocalRankingManager.Instance.GetRanking();
        rankingText.text = "";

        for (int i = 0; i < scores.Count; i++)
        {
            rankingText.text += $"{i + 1}. {scores[i]}\n";
        }
    }
}

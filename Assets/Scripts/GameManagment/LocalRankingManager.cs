using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RankingData
{
    public List<int> scores = new List<int>();
}

public class LocalRankingManager : MonoBehaviour
{
    public static LocalRankingManager Instance;
    public RankingData rankingData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadRanking();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScoreToRanking(int score)
    {
        rankingData.scores.Add(score);
        rankingData.scores.Sort((b, a) => b.CompareTo(a)); // Ordenar de menor a mayor

        if (rankingData.scores.Count > 10) // Mantener un top 10
        {
            rankingData.scores.RemoveAt(rankingData.scores.Count - 1);
        }
        SaveRanking();
    }

    public void ResetScores()
    {
        rankingData.scores.Clear();
        SaveRanking();
        print("Ranking reset");
    }

    public void SaveRanking()
    {
        string json = JsonUtility.ToJson(rankingData);
        PlayerPrefs.SetString("Ranking", json);
        PlayerPrefs.Save();
    }

    public void LoadRanking()
    {
        if (PlayerPrefs.HasKey("Ranking"))
        {
            string json = PlayerPrefs.GetString("Ranking");
            rankingData = JsonUtility.FromJson<RankingData>(json);
        }
        else
        {
            rankingData = new RankingData();
        }
    }

    public List<int> GetRanking()
    {
        return rankingData.scores;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    LocalRankingManager rankingManager;

    public static GameManager Instance;

    private void Start()
    {
        rankingManager = GetComponent<LocalRankingManager>();
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
    private void Update()
    {
        
        // Reseteo de BBDD
       if (Input.GetKeyUp(KeyCode.V)){

           rankingManager.ResetScores();

       }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    LocalRankingManager rankingManager;

    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        

        // Reseteo de BBDD
        if (Input.GetKeyUp(KeyCode.V))
        {

            rankingManager.ResetScores();

        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Timer timer = collision.GetComponent<Timer>();
            if (timer != null)
            {
                timer.StopTimer(); // Detiene el cronómetro
            }

            // Opcional: Carga la escena del ranking
            UnityEngine.SceneManagement.SceneManager.LoadScene("FinalDisplay");
        }
    }
}

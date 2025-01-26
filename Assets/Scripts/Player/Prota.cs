using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prota : MonoBehaviour
{
    Animator anim; // Referencia al Animator
    Rigidbody2D rb; // Referencia al Rigidbody2D
    public float velocidad; // Variable velocidad
    public float salto; // Variable salto
    public bool corriendo;
    public bool enSuelo;

    [SerializeField] Timer timer; // Referencia al script Timer

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Asignamos nuestro Rigidbody2D a la referencia
        velocidad = 9f;
        salto = 20f;

        // Asegúrate de que el temporizador esté inactivo al inicio
        if (timer != null)
        {
            timer.StopTimer(); // Asegúrate de que el temporizador no esté corriendo al inicio
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y); // Velocidad en el eje x e y

        anim.SetBool("cara", false); // Pone en False la variable del Animator: cara

        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetBool("cara", true); // Pone en True la variable del Animator: cara
        }

        if (corriendo)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);

            anim.SetBool("corriendo", true); // Pone en True la variable del Animator: corriendo
        }

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo && corriendo)
        {
            print("Has pulsado tecla Space");

            rb.velocity = new Vector2(0, salto); // Vector en el que se hará el salto
            anim.SetBool("saltando", true); // Pone en True la variable del Animator: saltando
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprueba que tocas un objeto que tiene como tag "Suelo"
        if (collision.gameObject.tag == "Suelo")
        {
            enSuelo = true; // Cambia la variable a true
            anim.SetBool("saltando", false); // Pone en False la variable del Animator: saltando
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            enSuelo = false; // Cambia la variable a false
        }
    }

    public void correr()
    {
        corriendo = true;
        anim.SetBool("corriendo", true); // Pone en True la variable del Animator: corriendo

        // Inicia el temporizador cuando el personaje comienza a correr
        if (timer != null)
        {
            timer.StartTimer();
        }
    }

}

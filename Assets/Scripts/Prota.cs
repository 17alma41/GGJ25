using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prota : MonoBehaviour
{

    Rigidbody2D rb; //Referencia a un rigidbody2d
    float velocidad; //Variable velocidad
    float salto; //Variable salto
    public bool corriendo; 
    public bool enSuelo;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //Asignamos nuestro rigidbody2d a la referencia
        velocidad = 3f;
        salto = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y); //velocidad en el eje x e y

        if (Input.GetKeyDown(KeyCode.Return))
        {

            corriendo = true;
        }


        if (corriendo)
        {

            rb.velocity = new Vector2(velocidad, rb.velocity.y); 

            
        }


        if (Input.GetKeyDown(KeyCode.Space) && enSuelo && corriendo)
        {

            print("Has pulsado tecla space");

            
            rb.velocity = new Vector2(0, salto); //vector en el que se hara el salto
            

        }

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Comprueba qur tocas un objeto que tiene como tag suelo
        if (collision.gameObject.tag == "Suelo")
        {

            enSuelo = true; //Cambia la variable a true
            
        }
    }

    //Comprueba que ya no estas tocando algo con una colsiion trigger. Para que se pueda detectar, antes has tenido que tocar algo trigger
    private void OnCollisionExit2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Suelo")
        {

            enSuelo = false; //Cambia la variable a false

        }
    }

}

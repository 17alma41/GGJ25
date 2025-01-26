using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim; //regerencia al animator

    [Header("Movement Settings")]
    [SerializeField] float movementSpeed = 5f; 
    bool isMoving = false;

    [Header("Ground Settings")]
    [SerializeField] LayerMask groundLayer; 
    [SerializeField] Transform groundCheckPoint; 

    [Header("Jump Settings")]
    [SerializeField] KeyCode keyJump = KeyCode.Space; 
    [SerializeField] float jumpForce = 10f; 


    bool isGrounded; 

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = CheckIfGrounded();

        if(Input.GetKeyDown(KeyCode.Return))
        {
            isMoving = true;
        }

        Jump();

    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            MoveRight();
           

        }
    }

    void MoveRight()
    {
        transform.Translate(new Vector2(movementSpeed * Time.deltaTime, 0));
        
    }

    void Jump()
    {

        if (Input.GetKeyDown(keyJump) && isGrounded && isMoving)
        {
            print("saltas");
           
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("saltando", true);
        }

        if (isGrounded)
        {
            print("suelo");
            anim.SetBool("saltando", false);
           
        }
       
    }

    bool CheckIfGrounded()
    {

        RaycastHit2D hit = Physics2D.BoxCast(
            groundCheckPoint.position,
            groundCheckPoint.localScale,
            0f,
            Vector2.down,
            0.2f,
            groundLayer
        );

        // Devuelve true si tocamos el suelo
        return hit.collider != null;

    }
}

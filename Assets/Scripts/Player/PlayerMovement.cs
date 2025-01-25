using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Movement Settings")]
    [SerializeField] float movementSpeed = 5f; 
    bool isMoving = false;

    [Header("Ground Settings")]
    [SerializeField] LayerMask groundLayer; 
    [SerializeField] Transform groundCheckPoint; 

    [Header("Jump Settings")]
    [SerializeField] KeyCode keyJump = KeyCode.Space; 
    [SerializeField] float jumpForce = 10f; 

    [Header("Gravity Settings")]
    [SerializeField] float defaultGravity = 1f;
    [SerializeField] float fallingGravity = 2f;

    bool isGrounded; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = defaultGravity; 
    }

    void Update()
    {
        isGrounded = CheckIfGrounded();

        if(Input.GetKeyDown(KeyCode.Return))
        {
            isMoving = true;
        }

        if (Input.GetKeyDown(keyJump) && isGrounded && isMoving)
        {

            Jump();
        }

        AdjustGravity();
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
        rb.velocity = new Vector2 (movementSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
    }

    void AdjustGravity()
    {
        if (rb.velocity.y < 0) 
        {
            rb.gravityScale = fallingGravity; 
        }
        else
        {
            rb.gravityScale = defaultGravity; 
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

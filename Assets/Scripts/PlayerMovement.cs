using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float input;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float slamForce = 1f;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isSlamming;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        velocity = rb.velocity;

        if(!isGrounded && Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("Conditions satisfied.");
            transform.Translate(Vector3.down * slamForce);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

}

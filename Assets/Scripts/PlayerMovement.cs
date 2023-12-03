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
    [SerializeField] private bool isGrounded;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundRadius;
    [SerializeField] private Transform groundCheckCollider;

    public bool isSlamming;
    public bool IsSlamming => isSlamming;


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


        if(!isGrounded && Input.GetKeyDown(KeyCode.S) && !isSlamming)
        {
            Debug.Log("Slam coroutine started.");
            StartCoroutine(Slam());
        }

        GroundCheck();
    }


    private void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position,groundRadius,groundLayer);
        if(colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    IEnumerator Slam()
    {
        isSlamming = true;

        while (!isGrounded)
        {
            transform.Translate(Vector3.down * slamForce);

            yield return null;
        }

        yield return new WaitForSeconds(.1f); /* update rate'den dolayi isSlamming aninda falselandiginda bariyer kirilmasi
                                               * gerceklesmiyor. .1f gibi bir deger bekledikten sonra kapatilinca
                                               * isSlamming degerinin true olma araligi, bariyeri kirmaya yetiyor. */

        isSlamming = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckCollider.position, groundRadius);
    }
}

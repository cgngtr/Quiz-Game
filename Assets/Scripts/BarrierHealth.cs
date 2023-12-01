using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Espace is pressed.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Enter");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("CollisionStay2D: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            gameObject.SetActive(false);
            Debug.Log("A");
        }
    }
}

using System.Collections;
using UnityEngine;

public class BarrierHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        if (_playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape is pressed.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Debug.Log("Enter");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("CollisionStay2D: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            if (_playerMovement != null && _playerMovement.IsSlamming)
            {
                Destroy(gameObject);
                Debug.Log("A");
            }
        }
    }


}

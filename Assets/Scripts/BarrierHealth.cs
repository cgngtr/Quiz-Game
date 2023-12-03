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
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("CollisionStay2D: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            if (_playerMovement != null && _playerMovement.isSlamming)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }


}

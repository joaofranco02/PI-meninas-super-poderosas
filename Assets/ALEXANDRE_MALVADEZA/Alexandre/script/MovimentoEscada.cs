using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoEscada : MonoBehaviour
{
    private float vertical;
    [SerializeField] private float speed = 8f;
    private bool escada;
    private bool escalanda;

    public Rigidbody2D playerRb;

    void Start()
    {
        // Initialization if needed
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (escada && Mathf.Abs(vertical) > 0f)
        {
            escalanda = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("escada"))
        {
            escada = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("escada"))
        {
            escada = false;
            escalanda = false;
        }
    }

    private void FixedUpdate()
    {
        if (escalanda)
        {
            playerRb.gravityScale = 0f;
            playerRb.velocity = new Vector2(playerRb.velocity.x, vertical * speed);
        }
        else
        {
            playerRb.gravityScale = 2f;
        }
    }
}

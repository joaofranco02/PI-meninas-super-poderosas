using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;
    public float jumpForce = 30f;  // Aumente o valor do pulo

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisão com o jogador detectada!");
            anim.SetTrigger("pulo");
            Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                Debug.Log("Força de pulo aplicada: " + jumpForce);
            }
        }
    }
}

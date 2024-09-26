using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;
    public float jumpForce;

    void Start()
    {
        anim = GetComponent<Animator>();  // Corrected GetComponent and Animator
    }

    void Update()
    {
        // Currently not used
    }

    private void OnCollisionEnter2D(Collision2D col)  // Corrected Collision2D
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("pulo");  // Corrected SetTrigger
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  // Corrected GetComponent and Impulse
        }
    }
}

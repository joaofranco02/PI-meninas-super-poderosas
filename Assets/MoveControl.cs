using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movecontrol : MonoBehaviour
{

    [SerializeField] Vector3 _move;
    [SerializeField] Rigidbody2D _rb;
    bool _facingRight;
    [SerializeField] float _SPEED;

    //pulo plataforma
    bool _checkgroud;
    [SerializeField] float _forcejump;
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();


    }
  void Update()
    {
        _rb.velocity = new Vector2(_move.x * _SPEED, _rb.velocity.y);

        if (_move.x > 0 && _facingRight == true)
        {
            flip();

        }
        else if (_move.x < 0 && _facingRight == false)
        {
            flip();
        }
    }
    public void SetMove(InputAction.CallbackContext value)

    {
        _move = value.ReadValue<Vector3>();

    }

    //pulo plataforma
    public void SetJump(InputAction.CallbackContext value)

    {
        if (_checkgroud == true)
        {
          _rb.AddForce(Vector2.up * _forcejump, ForceMode2D.Impulse);

        }


    }

    void flip()

    {
        _facingRight = !_facingRight;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector2(x, transform.localScale.y);
    }
    //pulo plataforma
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            Debug.Log("tocou no chao");

        _checkgroud = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
            Debug.Log("saiu no chao");

        _checkgroud = false;
    }

}



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class MoveControl : MonoBehaviour
{
    [SerializeField] Vector3 _move;
    Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _forceJump;

    bool _facingRight;
    bool _facingUp;

    bool _checkGround;
    [SerializeField] float _andando;
    [SerializeField] Animator _anim;

    [SerializeField] LifeControl _lifeControl;
    [SerializeField] bool _invuneravel;
    [SerializeField] SpriteRenderer[] _spriteRenderer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lifeControl = Camera.main.GetComponent<LifeControl>();
    }
    void Update()
    {
        _rb.velocity = new Vector2(_move.x * _speed, _rb.velocity.y);

        _andando = MathF.Abs(_move.x);


        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject bullet = BalaPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                //bullet.transform.position = turret.transform.position;
                // bullet.transform.rotation = turret.transform.rotation;
                bullet.SetActive(true);
            }
        }


        _anim.SetFloat("speedAnim", _andando);
        _anim.SetBool("CheckGround", _checkGround);
        _anim.SetFloat("speedY", _rb.velocity.y);

        if (_move.x > 0 && _facingRight == true)
        {
            flip();
        }
        else if (_move.x < 0 && _facingRight == false)
        {
            flip();
        }

        if (_move.y < 0 && _facingUp == true)
        {
            //  flipY();
        }
        else if (_move.y > 0 && _facingUp == false)
        {
            //flipY();
        }
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector3>();
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if (_checkGround == true)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
        }

    }

    void flip()
    {
        _facingRight = !_facingRight;
        float x = transform.localScale.x;
        x *= -1;

        transform.localScale = new Vector2(x, transform.localScale.y);
    }

    void flipY()
    {
        _facingUp = !_facingUp;
        float y = transform.localScale.y;
        y *= -1;

        transform.localScale = new Vector2(transform.localScale.x, y);
    }

    void Vuneravel()
    {
        _invuneravel = false;
    }

    private IEnumerator HitTime()
    {
        while (_invuneravel == true)
        {
            for (int i = 0; i < _spriteRenderer.Length; i++)
            {
                _spriteRenderer[i].color = new Color(1, 1, 1, 0.5f);
            }
            yield return new WaitForSeconds(0.15f);
            for (int i = 0; i < _spriteRenderer.Length; i++)
            {
                _spriteRenderer[i].color = new Color(1, 1, 1, 1f);
            }
            yield return new WaitForSeconds(0.15f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _checkGround = true;
        }
        if (collision.gameObject.CompareTag("Inimigo") && _invuneravel == false)
        {
            _lifeControl.PerdeVida();
            _invuneravel = true;
            Invoke("Vuneravel", 2);
            StartCoroutine(HitTime());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _checkGround = false;
        }
    }
}

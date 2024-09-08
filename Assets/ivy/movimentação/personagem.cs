using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
   { [SerializeField] Vector3 _move;
    [SerializeField] Rigidbody2D _rb;
    bool _facingRight;
    [SerializeField] float _SPEED;
     [SerializeField] Animator anim;

    //pulo plataforma
     [SerializeField] float jumpForce;

    

    void Start()
    {
      _rb = GetComponent<Rigidbody2D>();

       anim = GetComponent<Animator>();
    
    }


  void Update()
    {

        jump();
       
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
   
    

   

    void flip()

    {
        _facingRight = !_facingRight;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector2(x, transform.localScale.y);
    }
    //pulo plataforma
   
  void jump()
  {
    if(Input.GetKeyDown(KeyCode.Space))
    {
        _rb.velocity = new Vector2(0,jumpForce);
       
    }
     
     }
  
}
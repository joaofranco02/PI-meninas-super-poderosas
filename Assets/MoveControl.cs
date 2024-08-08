using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControl : MonoBehaviour
{

    [SerializeField] Vector3 _move;
    [SerializeField] Rigidbody2D _rb;



    // Start is called before the first frame update
    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        _rb.velocity = new Vector3(_move.x, _rb.velocity.y);

    }





    public void SetMove(InputAction.CallbackContext value)
    {

        _move = value.ReadValue<Vector3>();

    }
}
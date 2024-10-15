using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float distancia;
    public float speed;
    public Transform playerPos;
    public Rigidbody2D flyt;

    private void Start()
    {

    }


    void Update()
    {
        distancia = Vector2.Distance(transform.position, playerPos.position);

        if (distancia < 4)
        {
            Seguir();
        }
    }

    private void Seguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }


}

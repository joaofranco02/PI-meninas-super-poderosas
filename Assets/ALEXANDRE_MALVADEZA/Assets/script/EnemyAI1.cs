using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI1 : MonoBehaviour
{
    public float distancia;
    public float speed;
    public Transform playerPos;
    public Rigidbody2D flyt;
    private bool olhandoParaDireita = true; // Controle da dire��o

    private void Start()
    {

    }

    void Update()
    {
        distancia = Vector2.Distance(transform.position, playerPos.position);

        if (distancia < 4)
        {
            Seguir();
            VirarParaPlayer(); // Ajusta a dire��o
        }
    }

    private void Seguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    private void VirarParaPlayer()
    {
        // Verifica a posi��o do jogador em rela��o ao inimigo e ajusta se necess�rio
        if (playerPos.position.x > transform.position.x && !olhandoParaDireita)
        {
            Virar(); // Vira para a direita
        }
        else if (playerPos.position.x < transform.position.x && olhandoParaDireita)
        {
            Virar(); // Vira para a esquerda
        }
    }

    private void Virar()
    {
        // Inverte o valor da vari�vel de controle de dire��o
        olhandoParaDireita = !olhandoParaDireita;

        // Multiplica o eixo X da escala por -1 para virar o sprite
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
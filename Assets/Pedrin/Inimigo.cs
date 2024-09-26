using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform player; // Referência para o jogador
    public float moveSpeed = 2f; // Velocidade do inimigo
    public float attackDistance = 2f; // Distância para iniciar o ataque
    public float detectionRange = 10f; // Distância para seguir o jogador

    private bool isAttacking = false;
    private Animator animator; // Referência ao Animator

    // Start é chamado antes do primeiro frame
    void Start()
    {
        // Pega o componente Animator no objeto inimigo
        animator = GetComponent<Animator>();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Se o jogador estiver dentro da área de detecção
        if (distanceToPlayer < detectionRange && distanceToPlayer > attackDistance)
        {
            FollowPlayer();
        }
        else if (distanceToPlayer <= attackDistance)
        {
            AttackPlayer();
        }
        else
        {
            StopMoving();
            StopAttacking();
        }
    }

    void FollowPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Definir animação de movimento
        animator.SetBool("isMoving", true);
        animator.SetBool("isAttacking", false);
    }

    void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Debug.Log("Inimigo está atacando!");

            // Definir animação de ataque
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);

            // Aqui você pode adicionar lógica de dano ao jogador
        }
    }

    void StopMoving()
    {
        // Parar animação de movimento
        animator.SetBool("isMoving", false);
    }

    void StopAttacking()
    {
        if (isAttacking)
        {
            isAttacking = false;
            Debug.Log("Inimigo parou de atacar.");

            // Parar animação de ataque
            animator.SetBool("isAttacking", false);
        }
    }
}
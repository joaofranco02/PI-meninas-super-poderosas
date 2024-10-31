using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 2f; // Velocidade do inimigo
    public float detectionRange = 5f; // Distância em que o inimigo detecta o jogador
    private Transform player; // Referência ao transform do jogador

    private void Start()
    {
        // Encontrar o jogador pela tag
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            // Calcular a distância entre o inimigo e o jogador
            float distance = Vector2.Distance(transform.position, player.position);

            // Se o jogador estiver dentro do alcance de detecção, seguir o jogador
            if (distance < detectionRange)
            {
                FollowPlayer();
            }
        }
    }

    private void FollowPlayer()
    {
        // Calcular a direção do inimigo para o jogador
        Vector2 direction = (player.position - transform.position).normalized;

        // Mover o inimigo na direção do jogador
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}

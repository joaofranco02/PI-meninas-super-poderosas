using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 2f; // Velocidade do inimigo
    public float detectionRange = 5f; // Dist�ncia em que o inimigo detecta o jogador
    private Transform player; // Refer�ncia ao transform do jogador

    private void Start()
    {
        // Encontrar o jogador pela tag
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            // Calcular a dist�ncia entre o inimigo e o jogador
            float distance = Vector2.Distance(transform.position, player.position);

            // Se o jogador estiver dentro do alcance de detec��o, seguir o jogador
            if (distance < detectionRange)
            {
                FollowPlayer();
            }
        }
    }

    private void FollowPlayer()
    {
        // Calcular a dire��o do inimigo para o jogador
        Vector2 direction = (player.position - transform.position).normalized;

        // Mover o inimigo na dire��o do jogador
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}

using UnityEngine;
using UnityEngine.AI; // Necessário para usar o NavMeshAgent

public class inimigo : MonoBehaviour
{
    public Transform player; // Referência ao personagem principal
    public float detectionRange = 10f; // Distância máxima para detectar o jogador

    private NavMeshAgent agent; // Referência ao NavMeshAgent
    private Transform enemyTransform; // Referência à transformação do inimigo

    void Start()
    {
        // Obtém o componente NavMeshAgent no início
        agent = GetComponent<NavMeshAgent>();
        enemyTransform = transform;
    }

    void Update()
    {
        if (player == null) return; // Se o jogador não estiver definido, não faz nada

        // Calcula a distância entre o inimigo e o jogador
        float distanceToPlayer = Vector3.Distance(enemyTransform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Move o inimigo em direção ao jogador
            agent.SetDestination(player.position);
        }
        else
        {
            // Se o jogador estiver fora do alcance, o inimigo para
            agent.ResetPath();
        }
    }
}

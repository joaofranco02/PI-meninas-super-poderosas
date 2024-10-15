using UnityEngine;
using UnityEngine.AI; // Necess�rio para usar o NavMeshAgent

public class inimigo : MonoBehaviour
{
    public Transform player; // Refer�ncia ao personagem principal
    public float detectionRange = 10f; // Dist�ncia m�xima para detectar o jogador

    private NavMeshAgent agent; // Refer�ncia ao NavMeshAgent
    private Transform enemyTransform; // Refer�ncia � transforma��o do inimigo

    void Start()
    {
        // Obt�m o componente NavMeshAgent no in�cio
        agent = GetComponent<NavMeshAgent>();
        enemyTransform = transform;
    }

    void Update()
    {
        if (player == null) return; // Se o jogador n�o estiver definido, n�o faz nada

        // Calcula a dist�ncia entre o inimigo e o jogador
        float distanceToPlayer = Vector3.Distance(enemyTransform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Move o inimigo em dire��o ao jogador
            agent.SetDestination(player.position);
        }
        else
        {
            // Se o jogador estiver fora do alcance, o inimigo para
            agent.ResetPath();
        }
    }
}

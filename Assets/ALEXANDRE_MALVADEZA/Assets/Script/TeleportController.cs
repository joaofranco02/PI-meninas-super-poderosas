using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform teleportTarget; // Alvo para onde o jogador ser� teleportado
    public GameObject player; // Refer�ncia ao jogador
    public Color teleportAreaColor = Color.cyan; // Cor para a �rea de teleporte
    public KeyCode teleportKey = KeyCode.T; // Tecla para ativar o teleporte

    private bool isPlayerInTeleportArea = false; // Verifica se o jogador est� na �rea de teleporte

    private void OnDrawGizmos()
    {
        // Desenha a �rea onde o teleporte ser� ativado
        Gizmos.color = teleportAreaColor;
        Gizmos.DrawWireCube(transform.position, GetComponent<Collider2D>().bounds.size);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            // Jogador entrou na �rea de teleporte
            isPlayerInTeleportArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            // Jogador saiu da �rea de teleporte
            isPlayerInTeleportArea = false;
        }
    }

    private void Update()
    {
        // Verifica se o jogador est� na �rea de teleporte e se a tecla foi pressionada
        if (isPlayerInTeleportArea && Input.GetKeyDown(teleportKey))
        {
            // Teletransporta o jogador para o destino
            player.transform.position = teleportTarget.position;
        }
    }
}
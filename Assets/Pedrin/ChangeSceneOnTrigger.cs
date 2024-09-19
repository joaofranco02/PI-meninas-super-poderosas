using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para acessar a troca de cenas

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena que será carregada
    public Transform spawnPoint; // Ponto onde o jogador irá aparecer ao voltar
    private bool isInZone = false; // Verifica se o jogador está na área de troca de cena

    // Variáveis estáticas para armazenar a posição do jogador ao trocar de cena
    private static Vector3 lastPosition;
    private static bool hasPositionSaved = false;

    private void Start()
    {
        // Se houver uma posição salva, reposiciona o jogador
        if (hasPositionSaved)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = lastPosition;
                hasPositionSaved = false; // Reseta a flag
            }
        }
    }

    private void Update()
    {
        // Se o jogador estiver na zona e apertar "F"
        if (isInZone && Input.GetKeyDown(KeyCode.F))
        {
            // Salva a posição atual do jogador
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                lastPosition = player.transform.position;
                hasPositionSaved = true;
            }

            // Carrega a próxima cena
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Detecta quando o jogador entra na área de mudança de cena
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }
    }

    // Detecta quando o jogador sai da área de mudança de cena
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para acessar a troca de cenas

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena que ser� carregada
    public Transform spawnPoint; // Ponto onde o jogador ir� aparecer ao voltar
    private bool isInZone = false; // Verifica se o jogador est� na �rea de troca de cena

    // Vari�veis est�ticas para armazenar a posi��o do jogador ao trocar de cena
    private static Vector3 lastPosition;
    private static bool hasPositionSaved = false;

    private void Start()
    {
        // Se houver uma posi��o salva, reposiciona o jogador
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
            // Salva a posi��o atual do jogador
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                lastPosition = player.transform.position;
                hasPositionSaved = true;
            }

            // Carrega a pr�xima cena
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Detecta quando o jogador entra na �rea de mudan�a de cena
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }
    }

    // Detecta quando o jogador sai da �rea de mudan�a de cena
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
        }
    }
}
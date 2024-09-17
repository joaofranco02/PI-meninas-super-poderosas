using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para acessar a troca de cenas

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string sceneName; // Nome da cena para onde o jogador será levado
    public KeyCode triggerKey = KeyCode.F; // Tecla para ativar a troca de cena
    public Color gizmoColor = Color.green; // Cor do gizmo para a área do trigger
    public Vector3 triggerAreaSize = new Vector3(5f, 5f, 0); // Tamanho da área do trigger
    public Vector3 triggerAreaPosition = new Vector3(0, 0, 0); // Posição da área do trigger
    private bool playerInTriggerArea = false; // Verifica se o jogador está na área

    private void Update()
    {
        // Se o jogador está na área e a tecla F foi pressionada
        if (playerInTriggerArea && Input.GetKeyDown(triggerKey))
        {
            // Muda a cena
            SceneManager.LoadScene(sceneName);
        }
    }

    // Detecta quando o jogador entra na área de trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Certifique-se de que o objeto tem a tag "Player"
        {
            playerInTriggerArea = true;
        }
    }

    // Detecta quando o jogador sai da área de trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTriggerArea = false;
        }
    }

    // Desenha a área do trigger no editor usando Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(triggerAreaPosition, triggerAreaSize);
    }

    // Desenha o collider que será a área de trigger
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(triggerAreaPosition, triggerAreaSize);
    }

    // Define a área de trigger como um BoxCollider2D
    private void OnValidate()
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
        }
        collider.isTrigger = true; // Define como um trigger
        collider.size = triggerAreaSize; // Define o tamanho do trigger
        collider.offset = triggerAreaPosition; // Define a posição do trigger
    }
}
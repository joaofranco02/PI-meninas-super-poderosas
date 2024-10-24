using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para acessar a troca de cenas

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena que será carregada
    public Transform spawnPoint; // Ponto onde o jogador irá aparecer ao voltar
    private bool isInZone = false; // Verifica se o jogador está na área de troca de cena

    // Variáveis estáticas para armazenar a posição, rotação e animação do jogador ao trocar de cena
    private static Vector3 lastPosition;
    private static Quaternion lastRotation;
    private static Vector2 lastVelocity;
    private static string lastAnimationState;
    private static bool hasStateSaved = false;

    private Animator playerAnimator;
    private Rigidbody2D playerRb;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Se houver um estado salvo, restaura o jogador
        if (hasStateSaved && player != null)
        {
            player.transform.position = lastPosition;
            player.transform.rotation = lastRotation;

            playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = lastVelocity; // Restaura a velocidade
            }

            playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator != null && !string.IsNullOrEmpty(lastAnimationState))
            {
                playerAnimator.Play(lastAnimationState); // Restaura o estado da animação
            }

            hasStateSaved = false; // Reseta a flag
        }
    }

    private void Update()
    {
        // Se o jogador estiver na zona e apertar "F"
        if (isInZone && Input.GetKeyDown(KeyCode.F))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            // Salva o estado atual do jogador
            if (player != null)
            {
                lastPosition = player.transform.position;
                lastRotation = player.transform.rotation;

                playerRb = player.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    lastVelocity = playerRb.velocity; // Salva a velocidade
                }

                playerAnimator = player.GetComponent<Animator>();
                if (playerAnimator != null)
                {
                    // Salva o estado da animação com base nos nomes "parado" e "correndo"
                    AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
                    if (stateInfo.IsName("parado"))
                    {
                        lastAnimationState = "parado";
                    }
                    else if (stateInfo.IsName("correndo"))
                    {
                        lastAnimationState = "correndo";
                    }
                }

                hasStateSaved = true;
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
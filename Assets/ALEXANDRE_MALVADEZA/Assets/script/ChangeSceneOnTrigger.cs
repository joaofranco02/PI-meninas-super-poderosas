using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para acessar a troca de cenas

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena que ser� carregada
    public Transform spawnPoint; // Ponto onde o jogador ir� aparecer ao voltar
    private bool isInZone = false; // Verifica se o jogador est� na �rea de troca de cena

    // Vari�veis est�ticas para armazenar a posi��o, rota��o e anima��o do jogador ao trocar de cena
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
                playerAnimator.Play(lastAnimationState); // Restaura o estado da anima��o
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
                    // Salva o estado da anima��o com base nos nomes "parado" e "correndo"
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir1: MonoBehaviour
{
    public Transform jogador;  // Refer�ncia ao Transform do jogador
    public Vector3 offset;     // A diferen�a de posi��o entre a c�mera e o jogador
    public float suavidade = 0.125f;  // Velocidade de suavidade da c�mera

    private void LateUpdate()
    {
        if (jogador != null)
        {
            // A posi��o desejada � a posi��o do jogador mais o offset
            Vector3 posicaoDesejada = jogador.position + offset;

            // Suaviza o movimento da c�mera em dire��o � posi��o desejada
            Vector3 posicaoSuavizada = Vector3.Lerp(transform.position, posicaoDesejada, suavidade);

            // Atualiza a posi��o da c�mera
            transform.position = posicaoSuavizada;
        }
    }
}
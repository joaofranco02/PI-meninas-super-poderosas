using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir1: MonoBehaviour
{
    public Transform jogador;  // Referência ao Transform do jogador
    public Vector3 offset;     // A diferença de posição entre a câmera e o jogador
    public float suavidade = 0.125f;  // Velocidade de suavidade da câmera

    private void LateUpdate()
    {
        if (jogador != null)
        {
            // A posição desejada é a posição do jogador mais o offset
            Vector3 posicaoDesejada = jogador.position + offset;

            // Suaviza o movimento da câmera em direção à posição desejada
            Vector3 posicaoSuavizada = Vector3.Lerp(transform.position, posicaoDesejada, suavidade);

            // Atualiza a posição da câmera
            transform.position = posicaoSuavizada;
        }
    }
}
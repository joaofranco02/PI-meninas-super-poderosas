using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float smoothSpeed = 0.125f; // Velocidade de suavização
    public Vector3 offset; // Deslocamento da câmera em relação ao jogador

    private void LateUpdate()
    {
        if (player != null)
        {
            // Nova posição da câmera com deslocamento
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}


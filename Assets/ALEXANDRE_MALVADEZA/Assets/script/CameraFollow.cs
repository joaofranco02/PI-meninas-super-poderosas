using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Refer�ncia ao jogador
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o
    public Vector3 offset; // Deslocamento da c�mera em rela��o ao jogador

    private void LateUpdate()
    {
        if (player != null)
        {
            // Nova posi��o da c�mera com deslocamento
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}


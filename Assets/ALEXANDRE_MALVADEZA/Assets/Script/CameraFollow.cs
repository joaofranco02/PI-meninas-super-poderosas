using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public Vector3 offset;   // Offset da câmera em relação ao jogador

    void LateUpdate()
    {
        // Atualiza a posição da câmera para seguir o jogador com um offset
        transform.position = player.position + offset;

    }
        public class _CameraFollow : MonoBehaviour
    {
        public Transform player;
        public Vector3 offset;
        public float smoothSpeed = 0.125f;

        void LateUpdate()
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

}



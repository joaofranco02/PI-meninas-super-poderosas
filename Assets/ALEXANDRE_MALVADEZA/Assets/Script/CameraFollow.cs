using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public Vector3 offset;   // Offset da c�mera em rela��o ao jogador

    void LateUpdate()
    {
        // Atualiza a posi��o da c�mera para seguir o jogador com um offset
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



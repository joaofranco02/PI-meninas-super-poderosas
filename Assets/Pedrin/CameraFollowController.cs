using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform target; // O objeto que a câmera deve seguir (substituindo "player")
    public BoxCollider2D cameraBounds; // Os limites da área da câmera (substituindo "bounds")

    private float minX, maxX, minY, maxY;
    private float cameraPosX, cameraPosY;
    private float halfCameraWidth, halfCameraHeight;

    private Camera mainCam; // Variável para a câmera principal

    void Start()
    {
        mainCam = Camera.main;

        // Calcula a metade da largura e altura da câmera com base no tamanho ortográfico
        halfCameraHeight = mainCam.orthographicSize;
        halfCameraWidth = halfCameraHeight * mainCam.aspect;

        // Obtém os limites da área permitida para a câmera
        minX = cameraBounds.bounds.min.x + halfCameraWidth;
        maxX = cameraBounds.bounds.max.x - halfCameraWidth;
        minY = cameraBounds.bounds.min.y + halfCameraHeight;
        maxY = cameraBounds.bounds.max.y - halfCameraHeight;
    }

    void LateUpdate()
    {
        // Posiciona a câmera no mesmo lugar que o alvo, mas com restrições
        cameraPosX = Mathf.Clamp(target.position.x, minX, maxX);
        cameraPosY = Mathf.Clamp(target.position.y, minY, maxY);

        // Move a câmera para a nova posição
        transform.position = new Vector3(cameraPosX, cameraPosY, transform.position.z);
    }

    // Função para desenhar os limites no editor
    void OnDrawGizmos()
    {
        if (cameraBounds != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(cameraBounds.bounds.center, cameraBounds.bounds.size);
        }
    }
}
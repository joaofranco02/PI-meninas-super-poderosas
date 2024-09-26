using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // O objeto que a câmera deve seguir
    public BoxCollider2D bounds; // Os limites da área da câmera

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camHalfWidth, camHalfHeight;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        // Calcula a metade da largura e altura da câmera com base no tamanho da ortográfica
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;

        // Obtém os limites da área permitida para a câmera
        xMin = bounds.bounds.min.x + camHalfWidth;
        xMax = bounds.bounds.max.x - camHalfWidth;
        yMin = bounds.bounds.min.y + camHalfHeight;
        yMax = bounds.bounds.max.y - camHalfHeight;
    }

    void LateUpdate()
    {
        // Posiciona a câmera no mesmo lugar que o jogador
        camX = Mathf.Clamp(player.position.x, xMin, xMax);
        camY = Mathf.Clamp(player.position.y, yMin, yMax);

        // Move a câmera para a nova posição
        transform.position = new Vector3(camX, camY, transform.position.z);
    }

    // Função para desenhar os limites no editor
    void OnDrawGizmos()
    {
        if (bounds != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(bounds.bounds.center, bounds.bounds.size);
        }
    }
}

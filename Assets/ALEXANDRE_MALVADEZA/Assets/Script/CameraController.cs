using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // O objeto que a c�mera deve seguir
    public BoxCollider2D bounds; // Os limites da �rea da c�mera

    private float xMin, xMax, yMin, yMax;
    private float camX, camY;
    private float camHalfWidth, camHalfHeight;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        // Calcula a metade da largura e altura da c�mera com base no tamanho da ortogr�fica
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;

        // Obt�m os limites da �rea permitida para a c�mera
        xMin = bounds.bounds.min.x + camHalfWidth;
        xMax = bounds.bounds.max.x - camHalfWidth;
        yMin = bounds.bounds.min.y + camHalfHeight;
        yMax = bounds.bounds.max.y - camHalfHeight;
    }

    void LateUpdate()
    {
        // Posiciona a c�mera no mesmo lugar que o jogador
        camX = Mathf.Clamp(player.position.x, xMin, xMax);
        camY = Mathf.Clamp(player.position.y, yMin, yMax);

        // Move a c�mera para a nova posi��o
        transform.position = new Vector3(camX, camY, transform.position.z);
    }

    // Fun��o para desenhar os limites no editor
    void OnDrawGizmos()
    {
        if (bounds != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(bounds.bounds.center, bounds.bounds.size);
        }
    }
}

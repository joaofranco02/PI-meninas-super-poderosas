using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform target; // O objeto que a c�mera deve seguir (substituindo "player")
    public BoxCollider2D cameraBounds; // Os limites da �rea da c�mera (substituindo "bounds")

    private float minX, maxX, minY, maxY;
    private float cameraPosX, cameraPosY;
    private float halfCameraWidth, halfCameraHeight;

    private Camera mainCam; // Vari�vel para a c�mera principal

    void Start()
    {
        mainCam = Camera.main;

        // Calcula a metade da largura e altura da c�mera com base no tamanho ortogr�fico
        halfCameraHeight = mainCam.orthographicSize;
        halfCameraWidth = halfCameraHeight * mainCam.aspect;

        // Obt�m os limites da �rea permitida para a c�mera
        minX = cameraBounds.bounds.min.x + halfCameraWidth;
        maxX = cameraBounds.bounds.max.x - halfCameraWidth;
        minY = cameraBounds.bounds.min.y + halfCameraHeight;
        maxY = cameraBounds.bounds.max.y - halfCameraHeight;
    }

    void LateUpdate()
    {
        // Posiciona a c�mera no mesmo lugar que o alvo, mas com restri��es
        cameraPosX = Mathf.Clamp(target.position.x, minX, maxX);
        cameraPosY = Mathf.Clamp(target.position.y, minY, maxY);

        // Move a c�mera para a nova posi��o
        transform.position = new Vector3(cameraPosX, cameraPosY, transform.position.z);
    }

    // Fun��o para desenhar os limites no editor
    void OnDrawGizmos()
    {
        if (cameraBounds != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(cameraBounds.bounds.center, cameraBounds.bounds.size);
        }
    }
}
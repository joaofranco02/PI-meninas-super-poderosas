using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f; // Velocidade do inimigo
    public Transform pointA; // Ponto de in�cio
    public Transform pointB; // Ponto de fim
    private Transform target; // Ponto atual de destino
    private bool movingRight = true; // Indica se o inimigo est� se movendo para a direita

    private void Start()
    {
        // Come�ar pelo ponto A
        target = pointB;
    }

    private void Update()
    {
        // Mover em dire��o ao ponto atual
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Se o inimigo alcan�ar o ponto atual, inverta a dire��o
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            SwitchDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // L�gica para quando o inimigo bate em algo
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SwitchDirection(); // Alternar dire��o ao colidir com um obst�culo
        }
    }

    private void SwitchDirection()
    {
        // Alternar entre os pontos
        target = target == pointA ? pointB : pointA;

        // Inverter a dire��o (virar o inimigo)
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Inverter o eixo X
        transform.localScale = scale; // Aplicar a nova escala
    }
}

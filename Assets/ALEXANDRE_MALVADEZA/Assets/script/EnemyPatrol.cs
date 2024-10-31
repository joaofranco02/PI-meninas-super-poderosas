using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f; // Velocidade do inimigo
    public Transform pointA; // Ponto de início
    public Transform pointB; // Ponto de fim
    private Transform target; // Ponto atual de destino
    private bool movingRight = true; // Indica se o inimigo está se movendo para a direita

    private void Start()
    {
        // Começar pelo ponto A
        target = pointB;
    }

    private void Update()
    {
        // Mover em direção ao ponto atual
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Se o inimigo alcançar o ponto atual, inverta a direção
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            SwitchDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Lógica para quando o inimigo bate em algo
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SwitchDirection(); // Alternar direção ao colidir com um obstáculo
        }
    }

    private void SwitchDirection()
    {
        // Alternar entre os pontos
        target = target == pointA ? pointB : pointA;

        // Inverter a direção (virar o inimigo)
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Inverter o eixo X
        transform.localScale = scale; // Aplicar a nova escala
    }
}

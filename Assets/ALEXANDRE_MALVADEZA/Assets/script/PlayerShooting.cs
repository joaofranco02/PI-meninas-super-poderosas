using System.Collections; // Adicione esta linha
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform shootPoint; // Ponto de onde o projétil será disparado
    public float projectileSpeed = 10f; // Velocidade do projétil

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Configurado para clicar ou pressionar Ctrl
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Criar o projétil
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Definir a velocidade do projétil na direção em que o jogador está voltado
        if (rb != null)
        {
            rb.velocity = transform.right * projectileSpeed; // Direção do projétil
        }

        // Ativar a animação de tiro
        animator.SetBool("isShooting", true);

        // Desativar a animação de tiro após um curto período
        StartCoroutine(ResetShootingAnimation());
    }

    private IEnumerator ResetShootingAnimation()
    {
        yield return new WaitForSeconds(0.1f); // Tempo da animação
        animator.SetBool("isShooting", false);
    }
}

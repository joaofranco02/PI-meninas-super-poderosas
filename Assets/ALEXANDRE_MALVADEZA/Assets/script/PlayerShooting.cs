using System.Collections; // Adicione esta linha
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do proj�til
    public Transform shootPoint; // Ponto de onde o proj�til ser� disparado
    public float projectileSpeed = 10f; // Velocidade do proj�til

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
        // Criar o proj�til
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Definir a velocidade do proj�til na dire��o em que o jogador est� voltado
        if (rb != null)
        {
            rb.velocity = transform.right * projectileSpeed; // Dire��o do proj�til
        }

        // Ativar a anima��o de tiro
        animator.SetBool("isShooting", true);

        // Desativar a anima��o de tiro ap�s um curto per�odo
        StartCoroutine(ResetShootingAnimation());
    }

    private IEnumerator ResetShootingAnimation()
    {
        yield return new WaitForSeconds(0.1f); // Tempo da anima��o
        animator.SetBool("isShooting", false);
    }
}

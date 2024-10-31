using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool porta;  // Marca se a porta est� acess�vel
    private GameObject novaPorta;  // Refer�ncia para a nova porta

    public Text moedaTxt;  // Refer�ncia ao Text UI que exibe a quantidade de moedas
    private int moeda;  // Contador de moedas

    public Text chaveTxt;  // Refer�ncia ao Text UI que exibe a quantidade de chaves
    private int chave;  // Contador de chaves

    public float speed;  // Velocidade do jogador
    public Rigidbody2D playerRb;  // Refer�ncia ao Rigidbody2D do jogador
    private float movePlayer;  // Entrada horizontal para movimenta��o

    public float jumpForce;  // For�a do pulo
    private bool isGrounded;  // Verifica��o se est� no ch�o

    private int vida;  // Vida atual do jogador
    private int vidaMaxima = 3;  // Vida m�xima do jogador

    [SerializeField] private Image vidaOn1;  // Imagem do cora��o ativo 1
    [SerializeField] private Image vidaOff1;  // Imagem do cora��o vazio 1

    [SerializeField] private Image vidaOn2;  // Imagem do cora��o ativo 2
    [SerializeField] private Image vidaOff2;  // Imagem do cora��o vazio 2

    [SerializeField] private Image vidaOn3;  // Imagem do cora��o ativo 3
    [SerializeField] private Image vidaOff3;  // Imagem do cora��o vazio 3

    public GameObject projectilePrefab; // Prefab do proj�til
    public Transform shootPoint; // Ponto de onde o proj�til ser� disparado
    public float projectileSpeed = 10f; // Velocidade do proj�til

    void Start()
    {
        novaPorta = GameObject.Find("novaPorta");
        moeda = 0;
        chave = 0;
        porta = false;
        vida = vidaMaxima;
        AtualizarVidaUI();
    }

    void Update()
    {
        novaposicao();

        moedaTxt.text = moeda.ToString();
        chaveTxt.text = chave.ToString();

        movePlayer = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(movePlayer * speed, playerRb.velocity.y);

        // Verifica se o jogador pressionou o bot�o de pular e se est� no ch�o
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;  // Define isGrounded como false quando o pulo � iniciado
        }

        // Atualiza a orienta��o do jogador
        if (movePlayer > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);  // Olhando para a direita
        }
        else if (movePlayer < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);  // Olhando para a esquerda
        }

        // Verifica se o jogador pressionou o bot�o de tiro
        if (Input.GetButtonDown("Fire1")) // "Fire1" � normalmente o bot�o esquerdo do mouse ou Ctrl
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
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("chao"))
        {
            isGrounded = true;  // Marca o jogador como no ch�o
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("chao"))
        {
            isGrounded = false;  // Marca o jogador como fora do ch�o
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("moeda"))
        {
            moeda++;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("chave"))
        {
            chave++;
            Destroy(col.gameObject);
            Debug.Log("Chave coletada! Total de chaves: " + chave);
        }
        else if (col.gameObject.CompareTag("porta") && chave > 0)
        {
            porta = true;
            chave--;
            Debug.Log("Porta aberta! Total de chaves restantes: " + chave);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("espinho"))
        {
            Dano();
        }
    }

    private void novaposicao()
    {
        if (porta && novaPorta != null)
        {
            playerRb.transform.position = novaPorta.transform.position;
            porta = false;
        }
    }

    private void Dano()
    {
        vida--;
        if (vida < 0) vida = 0;
        AtualizarVidaUI();

        if (vida <= 0)
        {
            SceneManager.LoadScene(2); // Corrigido
        }
    }

    private void AtualizarVidaUI()
    {
        vidaOn1.enabled = (vida >= 1);
        vidaOff1.enabled = !vidaOn1.enabled;

        vidaOn2.enabled = (vida >= 2);
        vidaOff2.enabled = !vidaOn2.enabled;

        vidaOn3.enabled = (vida >= 3);
        vidaOff3.enabled = !vidaOn3.enabled;
    }
}

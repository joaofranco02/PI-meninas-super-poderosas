using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool porta;  // Marca se a porta está acessível
    private GameObject novaPorta;  // Referência para a nova porta

    public Text moedaTxt;  // Referência ao Text UI que exibe a quantidade de moedas
    private int moeda;  // Contador de moedas

    public Text chaveTxt;  // Referência ao Text UI que exibe a quantidade de chaves
    private int chave;  // Contador de chaves

    public float speed;  // Velocidade do jogador
    public Rigidbody2D playerRb;  // Referência ao Rigidbody2D do jogador
    private float movePlayer;  // Entrada horizontal para movimentação

    public float jumpForce;  // Força do pulo
    private bool isGrounded;  // Verificação se está no chão

    private int vida;  // Vida atual do jogador
    private int vidaMaxima = 3;  // Vida máxima do jogador

    [SerializeField] private Image vidaOn1;  // Imagem do coração ativo 1
    [SerializeField] private Image vidaOff1;  // Imagem do coração vazio 1

    [SerializeField] private Image vidaOn2;  // Imagem do coração ativo 2
    [SerializeField] private Image vidaOff2;  // Imagem do coração vazio 2

    [SerializeField] private Image vidaOn3;  // Imagem do coração ativo 3
    [SerializeField] private Image vidaOff3;  // Imagem do coração vazio 3

    public GameObject projectilePrefab; // Prefab do projétil
    public Transform shootPoint; // Ponto de onde o projétil será disparado
    public float projectileSpeed = 10f; // Velocidade do projétil

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

        // Verifica se o jogador pressionou o botão de pular e se está no chão
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;  // Define isGrounded como false quando o pulo é iniciado
        }

        // Atualiza a orientação do jogador
        if (movePlayer > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);  // Olhando para a direita
        }
        else if (movePlayer < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);  // Olhando para a esquerda
        }

        // Verifica se o jogador pressionou o botão de tiro
        if (Input.GetButtonDown("Fire1")) // "Fire1" é normalmente o botão esquerdo do mouse ou Ctrl
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
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("chao"))
        {
            isGrounded = true;  // Marca o jogador como no chão
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("chao"))
        {
            isGrounded = false;  // Marca o jogador como fora do chão
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

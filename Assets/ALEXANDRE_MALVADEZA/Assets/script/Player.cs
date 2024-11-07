using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool porta;
    private GameObject novaPorta;

    public Text moedaTxt;
    private int moeda;

    public Text chaveTxt;
    private int chave;

    public float speed;
    public Rigidbody2D playerRb;
    private float movePlayer;

    public float jumpForce;
    private bool isGrounded;

    private int vida;
    private int vidaMaxima = 3;

    [SerializeField] private Image vidaOn1;
    [SerializeField] private Image vidaOff1;

    [SerializeField] private Image vidaOn2;
    [SerializeField] private Image vidaOff2;

    [SerializeField] private Image vidaOn3;
    [SerializeField] private Image vidaOff3;

    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 10f;

    private Animator animator;

    void Start()
    {
        novaPorta = GameObject.Find("novaPorta");
        moeda = 0;
        chave = 0;
        porta = false;
        vida = vidaMaxima;
        AtualizarVidaUI();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        novaposicao();

        moedaTxt.text = moeda.ToString();
        chaveTxt.text = chave.ToString();

        movePlayer = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(movePlayer * speed, playerRb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(movePlayer));

        // Configura a animação de pulo e queda
        animator.SetBool("IsJumping", !isGrounded && playerRb.velocity.y > 0);
        animator.SetBool("IsFalling", !isGrounded && playerRb.velocity.y < 0);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (movePlayer > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movePlayer < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("chao"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("chao"))
        {
            isGrounded = false;
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
            SceneManager.LoadScene(2);
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
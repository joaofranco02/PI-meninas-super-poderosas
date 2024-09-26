using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // Para carregar novas cenas

public class MoveControl : MonoBehaviour
{
    [SerializeField] Vector3 _move;
    Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _forceJump;

    bool _facingRight;
    bool _facingUp;

    bool _checkGround;
    [SerializeField] float _andando;
    [SerializeField] Animator _anim;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = new Vector2(_move.x * _speed, _rb.velocity.y);

        _andando = Mathf.Abs(_move.x);
        _anim.SetFloat("speedAnim", _andando);
        _anim.SetBool("CheckGround", _checkGround);
        _anim.SetFloat("speedY", _rb.velocity.y);

        if (_move.x > 0 && !_facingRight)
        {
            Flip();
        }
        else if (_move.x < 0 && _facingRight)
        {
            Flip();
        }
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector3>();
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if (_checkGround)
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D called with " + collision.gameObject.name); // Adicione esta linha para depuração

        if (collision.gameObject.CompareTag("ground"))
        {
            _checkGround = true;
            Debug.Log("Colidiu com o ground!");
        }
        else if (collision.gameObject.CompareTag("door"))
        {
            Debug.Log("Colidiu com a porta!");
            LoadNewScene();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            _checkGround = false;
            Debug.Log("Saiu do ground!");
        }
    }

    private void LoadNewScene()
    {
        string newSceneName = "NewSceneName"; // Substitua pelo nome correto da cena
        if (SceneManager.GetSceneByName(newSceneName) != null)
        {
            Debug.Log("Carregando nova cena: " + newSceneName);
            SceneManager.LoadScene(newSceneName);
        }
        else
        {
            Debug.LogError("Cena não encontrada: " + newSceneName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInimigo : MonoBehaviour
{
    Rigidbody2D _rig2d;
    [SerializeField] float speed; // Velocidade de movimento do inimigo
    public Transform _direcao; // Referência ao Transform do jogador
    public Transform _player;
    public float _disPlayer;
    public float _distanSeguir;
    public Transform[] _pos; // Referência ao Transform do jogador

    bool _checkLoop;
    void Start()
    {
        _rig2d = GetComponent<Rigidbody2D>();
        _direcao = _pos[0];
    }
    void FixedUpdate()
    {
        _disPlayer = Vector2.Distance(transform.position, _player.position);
        if(_disPlayer <= _distanSeguir)
        {
            _direcao = _player;
            _checkLoop = true;
        }
        else if(_checkLoop==true)
        {
            _checkLoop = false;
            _direcao = _pos[1];
        }



        // Calcule a direção para o jogador
        Vector2 direcao = (_direcao.position - transform.position).normalized;

        // Mova o inimigo
        _rig2d.MovePosition(_rig2d.position + direcao * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "pos1") 
        {
            Debug.Log("pos1");
            _direcao = _pos[1];
        }
        else if (collision.gameObject.name == "pos2")
        {
            Debug.Log("pos2");
            _direcao = _pos[0];
        }
    }
}

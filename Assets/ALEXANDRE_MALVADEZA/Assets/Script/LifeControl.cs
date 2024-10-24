using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour
{
    [SerializeField] int _quantLifes = 2;
    [SerializeField] Transform[] lifes;

    void Start()
    {
        // lifes[0].transform.localScale = Vector3.zero;
        // lifes[1].transform.localScale = Vector3.zero;
        // lifes[2].transform.localScale = Vector3.zero;
    }

    public void GanharVida()
    {
        if (_quantLifes < 2)
        {
            _quantLifes++;
            lifes[_quantLifes].transform.localScale = Vector3.one;
        }

    }
    public void PerdeVida()
    {
        if (_quantLifes >= 0)
        {
            lifes[_quantLifes].transform.localScale = Vector3.zero;
            _quantLifes--;
        }
    }
}
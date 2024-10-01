using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UIElements;

public class parallax : MonoBehaviour
{
    private float legth ;
    private float startpos ;
    public float parallaxEffect ;
    private Transform cam ;
    void Start()
    {
      startpos  = transform.position.x ;
        legth = (GetComponent<SpriteRenderer>().bounds.size.x) ;
        cam = Camera.main.transform ;
    }

    
    void Update()
    {
       
        float distancia = cam.transform.position.x * parallaxEffect ;
        transform.position = new Vector3 (startpos * distancia,transform.position.y,transform.position.z);
      
    }
}

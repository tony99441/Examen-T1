using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    
    public float velocidad = 8f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    

    private bool PosicionA = false;

    private const int Animacion_Caminar = 0;
    private const int Animacion_Morir = 1;
    private bool muerte = false;
    
    private Animator animator;
    private BoxCollider2D bx;
   
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
   
                sr.flipX = true;
                
                CambiarAnimacion(0); 
    }

  
    private void CambiarAnimacion(int animation)
    {
        animator.SetInteger("estado", animation);
    }

}
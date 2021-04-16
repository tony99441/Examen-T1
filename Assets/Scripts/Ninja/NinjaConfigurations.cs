using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaConfigurations : MonoBehaviour
{
    public float velocidadCorrer = 10;
    private Animator animator;
    private Rigidbody2D rb;
    public float fuerzaSalto = 10f;

    private Transform tr;
    
    private SpriteRenderer sr;
    private const int Animacion_Quieto = 3;
    private const int Animacion_Correr = 0;
    private const int Animacion_Saltar = 2;
    private const int Animacion_Morir =1;

    private Collider2D cl;

    public bool EstadoMuerte = false;
    private int contadorsalto = 0; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
        cl = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EstadoMuerte == false)
        {
            tr.localScale = new Vector3(0.53f, 0.516f, 1);
            rb.velocity = new Vector2(velocidadCorrer, rb.velocity.y);
            CambiarAnimacion(Animacion_Correr);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CambiarAnimacion(Animacion_Saltar);
                rb.velocity = Vector2.up * fuerzaSalto;
                contadorsalto++;
                if (contadorsalto == 10)
                {
                    velocidadCorrer = velocidadCorrer +5;
                    contadorsalto = 0; 
                }
            }
            
        }

      

        else
        {
            CambiarAnimacion(Animacion_Morir); 
        }
        
    }

    private void CambiarAnimacion(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Muerte")
        {
            EstadoMuerte = true;
        }

       
        
    }
}
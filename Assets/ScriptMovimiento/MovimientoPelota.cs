using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MovimientoPelota : MonoBehaviour
{

    //public float speed = 2.5f; 
    // Vector3 movimientoHorizontal = Vector3.right;
    // Vector3 movimientoVertical = Vector3 .up;
    //  Rigidbody2D rb;
    public MuevetePalo muevetePalo;

        [SerializeField] 
    private float initialVelocity = 4f;

   // [SerializeField]
    //private float velocityMultiplier = 1.1f;

    public Rigidbody2D ballRb;

   
    public Vector2 posicionPelota;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();

        // rb = GetComponent<Rigidbody2D>();
        //Launch();
        posicionPelota=transform.position;
        
    }
    void Update()
    {

       if (Input.GetKeyDown(KeyCode.Space))
       {


            Launch();
            transform.parent = null;


       }



    }



   private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity; 
        // Aplicar el movimiento al Rigidbody2D
        // rb.velocity = (movimientoHorizontal + movimientoVertical) * speed;

        //  transform.position += (movimientoHorizontal + movimientoVertical) * Time.deltaTime * speed; 
    }

    // Para aumental La velocidad
    /*
    private void  OnCollisioEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Palo")
        {
            
            ballRb.velocity *= velocityMultiplier;

        }

       

    
    }
  
    */
    // Faltaria añadir en continuos en collision detec rigidbody

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        float posicionPaloX = muevetePalo.gameObject.transform.position.x;
        if (collision.gameObject.tag == "HorizontalBajo")
        {

            ballRb.MovePosition(new Vector3(posicionPaloX, 155f, 0f));
            //gameObject.transform.position = new Vector3(posicionPaloX, 155f, 0f) ;
            float xVelocity = 1f;
            float yVelocity = 1f;
            ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
        }

        //gameObject.tranform.parent = Palo.tranform;

    }



}

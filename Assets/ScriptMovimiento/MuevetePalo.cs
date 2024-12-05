using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MuevetePalo : MonoBehaviour
{

    [SerializeField]
   GameObject capsula1;
    [SerializeField]
    GameObject capsula2;
    [SerializeField]
    GameObject capsula3;
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private float minXIN = 132f;  // Límite mínimo en el eje X (por ejemplo, la pared izquierda)
    [SerializeField]
    private float maxXIN = 980f;   // Límite máximo en el eje X (por ejemplo, la pared derecha)
    [SerializeField]
    private float minX = 132f;  // Límite mínimo en el eje X (por ejemplo, la pared izquierda)
    [SerializeField]
    private float maxX = 980f;   // Límite máximo en el eje X (por ejemplo, la pared derecha)
    private Rigidbody2D paloRb;
    public bool isInverted = false;

    [SerializeField]
    Vector2 positionPalo;

    private void Start()
    {


        paloRb = GetComponent<Rigidbody2D>();
        positionPalo = transform.localPosition;

    }

    void Update()
    {


        if(isInverted == false)
        { 
        // Obtener el movimiento horizontal
        float movement = Input.GetAxisRaw("Horizontal");

        // Calcular la nueva posición en el eje X
        float newPosX = transform.position.x + movement * speed * Time.deltaTime;

        // Limitar la posición en el eje X para que no traspase las paredes
        newPosX = Mathf.Clamp(newPosX, minX, maxX);


        // Asignar la nueva posición manteniendo la posición Y igual
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);



            //float movement = Input.GetAxisRaw("Horizontal");
            // transform.position += new Vector3(movement, 0 * speed * Time.deltaTime);
           
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {

            isInverted = !isInverted;
            


        }
        if (isInverted == true)
        {
            
            float movimiento = -Input.GetAxisRaw("Horizontal");
            float newPosXIn = -transform.position.x + -movimiento * speed * Time.deltaTime;
           // newPosXIn = Mathf.Clamp(-newPosXIn, minXIN, maxXIN);

            transform.position = new Vector3(-newPosXIn, transform.position.y, transform.position.z);
            //  Transform.osition(1,0,0);
            

        }


    }

   







    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "powerUp")
         {
            if (isInverted == true)
            { 
                isInverted = false;
                Destroy(other.gameObject);


            }


            if (isInverted == false)
            {


                isInverted = true;
        

            }
            


         }


        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    

    }

    public void ResetPlayer()
    {
        transform.position = positionPalo;
    }



}
/*
int seleccion = Random.Range(1, 5);
if (seleccion == 5)
{
    Instantiate(Capsule1, positionPalo, Quaternion.identity);
}
*/
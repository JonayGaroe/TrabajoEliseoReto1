using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
    public class MovimientoPelota : MonoBehaviour
    {
        public static MovimientoPelota instance;


    public MuevetePalo muevetePalo;  // Referencia al script del jugador (palo)
    public bool destruyeBloques = false;  // Indica si la pelota destruye bloques

    [SerializeField] private float initialVelocity = 4f;  // Velocidad inicial de la pelota

     [SerializeField] float velocidadReducida = 0.8f;  // Nueva velocidad reducida para el power-up (más lenta)
    private float velocidadActual;  // Velocidad actual de la pelota
    private bool powerUpActivo = false;  // Indica si el power-up está activo
     public float  velocidad = 5f;
    public Rigidbody2D ballRb;
    public Vector2 posicionPelota;
    bool bolaQ = true;

    // Temporizador para la duración del power-up
    private float timerPowerUp = 0f;  // Temporizador que lleva el control del power-up
    private float timerPowerUp2 = 10f;  // Temporizador que lleva el control del power-up

      private void Awake()
      {
        if(instance == null)
        {

            instance = this;

         
        }



      }


    void Start()
    {
        velocidadActual = initialVelocity;  // La velocidad inicial es la normal
        ballRb = GetComponent<Rigidbody2D>();
        posicionPelota = transform.position;
    }

    void Update()
    {
        ballRb.velocity = ballRb.velocity.normalized * velocidad;

        // Verificamos si el power-up está activo y actualizamos la velocidad
        if (powerUpActivo)
        {
            timerPowerUp -= Time.deltaTime;
            velocidad = velocidadReducida;

            if (timerPowerUp <= 0f)  // Si el tiempo se acaba, restauramos la velocidad
            {
                velocidad = initialVelocity;
                powerUpActivo = false;

            }

          

        }
        if (destruyeBloques)
        {
            timerPowerUp2 -= Time.deltaTime;

            if (timerPowerUp2 <= 0f)  // Si el tiempo se acaba, restauramos la velocidad
            {
                destruyeBloques = false;

            }



        }

        // Si la bola está en espera para ser lanzada
        if (bolaQ && Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
            transform.parent = null;
            bolaQ = false;
        }
    }

    // Método que lanza la pelota con una velocidad inicial aleatoria
    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * velocidadActual;
    }


    public void ActivarPowerUpDestruye(float duracion)
    {
        if (!destruyeBloques)
        {
            destruyeBloques = true;
            timerPowerUp = duracion;  // Establecer la duración del power-up
            Debug.Log("Power-up activado. Duración: " + duracion + " segundos.");
        }
    }

   


    // Método para activar el power-up (reduce la velocidad de la pelota)
    public void ActivarPowerUp(float duracion)
    {
        if (!powerUpActivo)
        {
            powerUpActivo = true;
            timerPowerUp = duracion;  // Establecer la duración del power-up
            Debug.Log("Power-up activado. Duración: " + duracion + " segundos.");
        }
    }

    // Método para desactivar el power-up y restaurar la velocidad
    private void DesactivarPowerUp()
    {
        powerUpActivo = false;
        velocidadActual = initialVelocity;  // Restauramos la velocidad normal de la pelota
        Debug.Log("Power-up desactivado. La velocidad vuelve a la normalidad.");
    }

    // Método para destruir bloques cuando se toque con la pelota
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destruyeBloques && collision.gameObject.CompareTag("bloquesss"))
        {
            Destroy(collision.gameObject);  // Destruye el bloque al colisionar
            Debug.Log("Bloque destruido por el power-up");
        }




    }


    // Método para cambiar la posición de la pelota al tocar un objeto con el tag "HorizontalBajo"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Aquí gestionamos el movimiento de la pelota con la barra/palo
        float posicionPaloX = muevetePalo.gameObject.transform.position.x;
        if (collision.gameObject.tag == "HorizontalBajo")
        {
            ballRb.MovePosition(new Vector3(posicionPaloX, 155f, 0f));
            float xVelocity = 1f;
            float yVelocity = 1f;
            ballRb.velocity = new Vector2(xVelocity, yVelocity) * velocidadActual;
            bolaQ = true;
           
        }
        

    }
}
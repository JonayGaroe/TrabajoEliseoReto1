using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasBloques : MonoBehaviour
{

    public static VidasBloques instance { get; private set; }

    public int bloqueVida;
    public float detectionRadius = 1f; // Radio de detección de colisiones

    private bool powerup = false;

    // Start is called before the first frame update
    public GameObject prefabPowerUp; // Prefab del power-up
    public float probabilidadPowerUp = 0.8f; // Probabilidad de que salga un power-up (20%)

    public GameObject prefabPowerUp2; // Prefab del power-up
    public float probabilidadPowerUp2 = 1f; // Probabilidad de que salga un power-up (20%)

    public GameObject prefabPowerUp3; // Prefab del power-up
    public float probabilidadPowerUp3 = 1f; // Probabilidad de que salga un power-up (20%)

    public GameObject prefabPowerUp4; // Prefab del power-up
    public float probabilidadPowerUp4 = 1f; // Probabilidad de que salga un power-up (20%)

    public GameObject prefabPowerUp5; // Prefab del power-up
    public float probabilidadPowerUp5 = 1f; // Probabilidad de que salga un power-up (20%)

    public delegate void BloqueDestruidoHandler();
    public event BloqueDestruidoHandler OnBloqueDestruido;



    public float duracionDestruccion = 10f;  // Duración total de la destrucción
    private float tiempoRestante;  // Tiempo restante para la destrucción gradual
    private bool enProcesoDeDestruccion = false;  // Si la destrucción está en curso


    void Awake()
    {

        instance = this;



    }


    void Start()
    {



        tiempoRestante = duracionDestruccion;






    }

    void Update()
    {




            // Si la destrucción está en proceso
            if (enProcesoDeDestruccion)
            {
                // Disminuir gradualmente la escala
                for (int i = 0; i < 10; i++) // Dividimos la destrucción en 10 pasos
                {
                    // Reduce el tamaño del objeto con el tiempo
                    transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime / duracionDestruccion);
                }

                // Si el tiempo de destrucción se ha agotado
                if (tiempoRestante <= 0f)
                {
                    // Finalmente destruimos el objeto
                    Destroy(gameObject);
                }
                else
                {
                    // Reducir el tiempo restante
                    tiempoRestante -= Time.deltaTime;
                }
            }
        



    








        // Verifica si las vidas llegaron a 0
        if (bloqueVida == 0)  // Cambiado de == 0 a <= 0
        {
            Debug.Log("Bloque destruido, instanciando power-up");
            if (Random.value < probabilidadPowerUp)
            {
                Debug.Log("Power-up instanciado en: " + transform.position);
                Instantiate(prefabPowerUp, transform.position, Quaternion.identity);
                Destroy(gameObject);  // Destruye el bloque
            }

            if (Random.value < probabilidadPowerUp2)
            {
                Debug.Log("Power-up instanciado en: " + transform.position);
                Instantiate(prefabPowerUp2, transform.position, Quaternion.identity);
                Destroy(gameObject);  // Destruye el bloque
            }

            if (Random.value < probabilidadPowerUp3)
            {
                Debug.Log("Power-up instanciado en: " + transform.position);
                Instantiate(prefabPowerUp3, transform.position, Quaternion.identity);
                Destroy(gameObject);  // Destruye el bloque
            }

            if (Random.value < probabilidadPowerUp4)
            {
                Debug.Log("Power-up instanciado en: " + transform.position);
                Instantiate(prefabPowerUp4, transform.position, Quaternion.identity);
                Destroy(gameObject);  // Destruye el bloque
            }
            if (Random.value < probabilidadPowerUp5)
            {
                Debug.Log("Power-up instanciado en: " + transform.position);
                Instantiate(prefabPowerUp5, transform.position, Quaternion.identity);
                Destroy(gameObject);  // Destruye el bloque
            }


        }
    }


   

    // Método para destruir el bloque
    public void DestruirBloque()
    {
        OnBloqueDestruido?.Invoke();  // Llama al evento cuando el bloque se destruye
        Destroy(gameObject); // Destruye el bloque
    }






}






















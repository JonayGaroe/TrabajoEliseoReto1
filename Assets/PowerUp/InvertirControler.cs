using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertirControler : MonoBehaviour
{
    public float duracionInversion = 7f; // Duraci�n del efecto en segundos

    private void OnTriggerEnter2D(Collider2D other)  // Cambi� OnTriggerEnter a OnTriggerEnter2D
    {
        Debug.Log("Power-up colisionado con: " + other.gameObject.name); // Verifica si la colisi�n se detecta

        if (other.CompareTag("Palo"))  // Verificar si la colisi�n es con el jugador
        {
            Debug.Log("Power-up tocado por el jugador: " + other.gameObject.name); // Confirmar que es el jugador

            MuevetePalo controlJugador = other.GetComponent<MuevetePalo>();
            if (controlJugador != null)
            {
                Debug.Log("Invirtiendo controles para el jugador: " + other.gameObject.name); // Confirmar que se invierten los controles
                controlJugador.InvertirControles(duracionInversion);  // Llamar para invertir los controles
                Destroy(gameObject);  // Destruir el power-up
            }
        }
    }
}
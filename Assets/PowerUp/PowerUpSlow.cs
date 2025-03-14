using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlow : MonoBehaviour
{
    public float duracionEfecto = 10f;  // Duración del efecto en segundos

    /* private void OnTriggerEnter2D(Collider2D other)
     {
         // Verificar si el objeto que tocó el power-up tiene el script MuevetePalo (el jugador)
         MuevetePalo jugador = other.GetComponent<MuevetePalo>();

         if (jugador != null)  // Solo aplicar el efecto si el objeto es el jugador
         {
             Debug.Log("Power-up recogido por el jugador");

             // Llamamos al script de la pelota directamente desde el jugador
             MovimientoPelota pelota = jugador.GetComponentInChildren<MovimientoPelota>();  // Accedemos al script de la pelota
             if (pelota != null)
             {
                 pelota.ActivarPowerUp(duracionEfecto);  // Aplicar el power-up a la pelota
             }
             else
             {
                 Debug.LogWarning("No se encontró el script de la pelota.");
             }

             // Destruir el power-up después de que sea recogido
             Destroy(gameObject);
         }
         else
         {
             Debug.LogWarning("El objeto que tocó el power-up no es el jugador.");
         }
     }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Palo"))
        {

            MovimientoPelota.instance.ActivarPowerUp(duracionEfecto);
            Destroy(gameObject);


        }



    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destruye el objeto cuando ya no es visible en la cámara
    }



}
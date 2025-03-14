using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpDestruye : MonoBehaviour
{

    public float duracionInversion = 10f; // Duraci�n del efecto en segundos

    private void OnTriggerEnter2D(Collider2D other)  // Cambi� OnTriggerEnter a OnTriggerEnter2D
    {

        if (other.CompareTag("Palo"))  // Verificar si la colisi�n es con el jugador
        {

            MovimientoPelota.instance.ActivarPowerUpDestruye(duracionInversion);
           // MovimientoPelota.instance.destruyebola()(duracionInversion);

            Destroy(gameObject);  // Destruir el power-up
           
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destruye el objeto cuando ya no es visible en la c�mara
    }



}

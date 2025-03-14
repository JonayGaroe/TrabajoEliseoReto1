using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpDuplicadoBola : MonoBehaviour
{
    // Variable p�blica para arrastrar el objeto desde el Inspector
    public GameObject bola;

    // Este m�todo duplicar� el objeto sin copiar su tag
    // Variable p�blica para arrastrar el objeto desde el Inspector

    // Este m�todo duplicar� el objeto sin copiar su tag
    private void OnTriggerEnter2D(Collider2D other)  // Cambi� OnTriggerEnter a OnTriggerEnter2D
    {
        if (other.CompareTag("Palo"))  // Verificar si la colisi�n es con el jugador
        {
            if (bola != null)
            {
               // Instanciamos el objeto actual en una nueva posici�n
               GameObject objetoDuplicado = Instantiate(bola, bola.transform.position + Vector3.right, bola.transform.rotation);

               // Eliminamos el tag del objeto duplicado
               objetoDuplicado.tag = "powerUp";  // Dejamos el tag vac�o o asignamos uno nuevo si lo deseas
                                                 // Hacemos que el Collider sea un Trigger
         

                // Aqu� puedes realizar otras modificaciones en el objeto duplicado si lo necesitas
                // Ejemplo: objetoDuplicado.name = "Duplicado sin tag";
                Destroy(gameObject);
            }
        }
             
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destruye el objeto cuando ya no es visible en la c�mara
    }

}
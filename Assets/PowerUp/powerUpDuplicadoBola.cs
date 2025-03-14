using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpDuplicadoBola : MonoBehaviour
{
    // Variable pública para arrastrar el objeto desde el Inspector
    public GameObject bola;

    // Este método duplicará el objeto sin copiar su tag
    // Variable pública para arrastrar el objeto desde el Inspector

    // Este método duplicará el objeto sin copiar su tag
    private void OnTriggerEnter2D(Collider2D other)  // Cambié OnTriggerEnter a OnTriggerEnter2D
    {
        if (other.CompareTag("Palo"))  // Verificar si la colisión es con el jugador
        {
            if (bola != null)
            {
               // Instanciamos el objeto actual en una nueva posición
               GameObject objetoDuplicado = Instantiate(bola, bola.transform.position + Vector3.right, bola.transform.rotation);

               // Eliminamos el tag del objeto duplicado
               objetoDuplicado.tag = "powerUp";  // Dejamos el tag vacío o asignamos uno nuevo si lo deseas
                                                 // Hacemos que el Collider sea un Trigger
         

                // Aquí puedes realizar otras modificaciones en el objeto duplicado si lo necesitas
                // Ejemplo: objetoDuplicado.name = "Duplicado sin tag";
                Destroy(gameObject);
            }
        }
             
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destruye el objeto cuando ya no es visible en la cámara
    }

}
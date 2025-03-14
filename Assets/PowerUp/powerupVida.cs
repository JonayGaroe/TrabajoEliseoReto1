using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupVida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        // Comprobamos si el objeto con el que colisionamos tiene la etiqueta "Palo"
        if (other.CompareTag("Palo"))
        {
            // Comprobar que la instancia de PartidaPerdida no sea null
            if (PartidaPerdida.instance != null)
            {
                PartidaPerdida.instance.ActivarVida();
            }
            else
            {
                Debug.LogError("La instancia de PartidaPerdida es null.");
            }

            // Destruimos el objeto (el power-up)
            Destroy(gameObject);
        }
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destruye el objeto cuando ya no es visible en la cámara
    }
}
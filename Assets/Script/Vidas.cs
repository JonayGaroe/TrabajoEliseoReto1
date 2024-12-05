using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Si deseas mostrar las vidas en una UI

public class VidaManager : MonoBehaviour
{
    public int vidas = 3; // N�mero de vidas iniciales
    public Text vidasText; // Referencia al texto de la UI que mostrar� las vidas (opcional)

    // M�todo para reducir las vidas cuando el cubo colisiona con algo
    private void OnCollisionEnter(Collision collision)
    {
        // Aqu� puedes colocar una condici�n para reducir vidas cuando colisiona con un objeto espec�fico
        // Por ejemplo, si colisiona con un objeto que tenga la etiqueta "Enemigo"
        if (collision.gameObject.CompareTag("bloquesss"))
        {

            ReducirVida();

        }
    }

    // M�todo para reducir las vidas
    void ReducirVida()
    {

        if (vidas > 0)
        {


            vidas--; // Resta una vida
            
            Debug.Log("Vidas restantes: " + vidas);
            FindObjectOfType<MuevetePalo>().ResetPlayer();
            FindObjectOfType<MovimientoPelota>().transform.parent = FindObjectOfType<MuevetePalo>().transform;
            FindObjectOfType<MovimientoPelota>().transform.position = FindObjectOfType<MovimientoPelota>().posicionPelota;
            FindObjectOfType<MovimientoPelota>().ballRb.velocity = Vector2.zero;
            gameObject.transform.parent = FindObjectOfType<MuevetePalo>().transform;

            // Actualiza el texto de la UI (si existe)
            if (vidasText != null)
            {
                


                vidasText.text = "Vidas: " + vidas;



            }

            // Si las vidas se acaban, puedes a�adir un evento como el fin del juego
            if (vidas == 0)
            {


                // Aqu� puedes llamar a alg�n m�todo para finalizar el juego o mostrar un mensaje
                Debug.Log("�Juego terminado!");



            }



        }


    }



}

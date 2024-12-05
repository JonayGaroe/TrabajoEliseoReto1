using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Bloques : MonoBehaviour
{
    public int bloquesCount = 30;
    public TextMeshProUGUI bloquesText;
    public TextMeshProUGUI bloquesText2;
    public int  bloquesPuntos = 20;
    public AudioClip Bloquefx;
    [SerializeField]
    GameObject CanvasGanar;
 //   [SerializeField]
//    GameObject Bola8;

    // Start is called before the first frame update
    void Start()
    {
        bloquesCount = 30;
   
    }

    // Update is called once per frame
    void Update()
    {

     

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
         //Asegurarnos de que la colisión es con un objeto con el tag correcto
        //if (other.CompareTag("bloquesss"))

        if (other.gameObject.CompareTag("bloquesss"))
        {
            // Verificar si el tag coincide antes de hacer el resto de la lógica
            // Destruir el objeto con el tag "bloquesss"
            other.collider.GetComponent<VidasBloques>().bloqueVida -= 1;
            if(other.collider.GetComponent<VidasBloques>().bloqueVida <= 0)
 
            {
                bloquesCount = bloquesCount - 1;

             Debug.Log("He tocado el Bloque " + bloquesCount);
             //destruir con tiempo
             //Destroy(other.gameObject,5f);
             Destroy(other.gameObject);
             bloquesText.text = bloquesCount.ToString();
             bloquesText2.text = bloquesCount.ToString();

                if (bloquesCount <= 0)
                {
                    Debug.Log("FUNCCIONA");
                    MapaAleatorio.instance.GenerarMapa();




                }



            }
        }


    /*    if (other.gameObject.tag.Contains("bloquesss"))
        {

            Destroy(other.gameObject);
            bloquesText.text = bloquesCount.ToString();
            bloquesText2.text = bloquesCount.ToString();

            

            // bloquesText.text = bloquesCount.ToString();
            // other.gameObject.SetActive(false);
            //  AudioSource.PlayClipAtPoint(Bloquefx, transform.position);
           




        }
    */
       if(bloquesCount <= 0)
       {
           

            CanvasGanar.SetActive(true);

            //Time.timeScale = 0;

       }
        /*
        if(CanvasGanar.activeSelf)
        {


            // Bola8.SetActive(false);
            Time.timeScale = 0f;

        }


        */
    }
    
}

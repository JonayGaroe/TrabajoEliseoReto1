using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Bloques : MonoBehaviour
{
    public static Bloques instance;
   // public GameObject[] powerup;
    public int bloquesCount = 30;
    public TextMeshProUGUI bloquesText;
    public TextMeshProUGUI bloquesText2;
    public int  bloquesPuntos = 20;
    public AudioClip Bloquefx;
    [SerializeField]
    GameObject CanvasGanar;
   
    [SerializeField]
    Vector2 positionPalo;

 

    public AudioClip destruirBloquefx;


    public int puntos = 10; // Puntos que otorga este bloque cuando es destruido






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
        if (other.gameObject.CompareTag("bloquesss"))
        {
            // Reducir la vida del bloque
            VidasBloques vidasBloques = other.collider.GetComponent<VidasBloques>();
            vidasBloques.bloqueVida -= 1;

            if (vidasBloques.bloqueVida <= 0)
            {
                // Agregar puntos al controlador
                GameController.instance.AgregarPuntos(puntos);
                bloquesCount -= 1;

                Debug.Log("He tocado el Bloque " + bloquesCount);

                // Instanciar el power-up si las vidas del bloque llegaron a 0
                if (Random.value < vidasBloques.probabilidadPowerUp)  // Esto verifica la probabilidad de que el power-up salga
                {
                    Instantiate(vidasBloques.prefabPowerUp, other.transform.position, Quaternion.identity);
                    Debug.Log("Power-up instanciado en: " + other.transform.position);
                }
                if (Random.value < vidasBloques.probabilidadPowerUp4)  // Esto verifica la probabilidad de que el power-up salga
                {
                    Instantiate(vidasBloques.prefabPowerUp4, other.transform.position, Quaternion.identity);
                    Debug.Log("Power-up instanciado en: " + other.transform.position);
                }
                if (Random.value < vidasBloques.probabilidadPowerUp2)  // Esto verifica la probabilidad de que el power-up salga
                {
                    Instantiate(vidasBloques.prefabPowerUp2, other.transform.position, Quaternion.identity);
                    Debug.Log("Power-up instanciado en: " + other.transform.position);
                }
                if (Random.value < vidasBloques.probabilidadPowerUp3)  // Esto verifica la probabilidad de que el power-up salga
                {
                    Instantiate(vidasBloques.prefabPowerUp3, other.transform.position, Quaternion.identity);
                    Debug.Log("Power-up instanciado en: " + other.transform.position);
                }
                if (Random.value < vidasBloques.probabilidadPowerUp5)  // Esto verifica la probabilidad de que el power-up salga
                {
                    Instantiate(vidasBloques.prefabPowerUp5, other.transform.position, Quaternion.identity);
                    Debug.Log("Power-up instanciado en: " + other.transform.position);
                }

                // Destruir el bloque despu�s de instanciar el power-up
                Destroy(other.gameObject);
                bloquesText.text = bloquesCount.ToString();
                //bloquesText2.text = bloquesCount.ToString();

              
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
        if (bloquesCount <= 0)
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

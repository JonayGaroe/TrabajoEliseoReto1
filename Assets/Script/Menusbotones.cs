    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;
public class Menusbotones : MonoBehaviour
{
    [SerializeField]
    GameObject startNivel;
    [SerializeField]
    GameObject nivel1;
    [SerializeField]
    GameObject nivel2;

    [SerializeField]
    GameObject atras;

    [SerializeField]
    GameObject antesNiveles;

    [SerializeField]
    GameObject despuesNiveles;

    [SerializeField] 
    GameObject menuPrincipal;

    [SerializeField]
    GameObject botonControles;
  //  [SerializeField]
   // GameObject canvasModos;
    [SerializeField]
    GameObject Bolaaa;
    [SerializeField]
    GameObject timesss;
    [SerializeField]
    GameObject Sonido;
    [SerializeField]
    GameObject ganar;
    [SerializeField]
    GameObject canvasfinal;

    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {


        Time.timeScale = 0;




    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            isPause = !isPause;

            if (isPause == true)
            {

                Time.timeScale = 0;
                menuPrincipal.SetActive(true);

            }

            if (isPause == false)
            {

                Time.timeScale = 1;
                menuPrincipal.SetActive(false);



            }



        }







    }
    public void startniveles()
    {
        Time.timeScale = 1;
        menuPrincipal.SetActive(false);
       // canvasModos.SetActive(true);
       // Bolaaa.SetActive(true);
        timesss.SetActive(true);
        
    }
    public void MenuPrincipal()
    {
        Time.timeScale = 0;
        menuPrincipal.SetActive(true);
        antesNiveles.SetActive(false);
        botonControles.SetActive(false);
        //Bolaaa.SetActive(false);
        Sonido.SetActive(false);

    }

    public void nivelear()
    {

        antesNiveles.SetActive(true);
        menuPrincipal.SetActive(false);





    }

    public void OpcionSonido()
    {

        Sonido.SetActive(true);
        menuPrincipal.SetActive(false);





    }
    public void Ayuda()
    {


        botonControles.SetActive(true);





    }

    public void quitarMenu()
    {
        menuPrincipal.SetActive(false);
      

    }

    public void ReintentarenAleatorio()
    {
        ganar.SetActive(false);
        canvasfinal.SetActive(false);
        SceneManager.LoadScene("Aleatorio"); 
        
    }


    public void reintentarotracosa()
    {
        ganar.SetActive(false);
        canvasfinal.SetActive(false);
        SceneManager.LoadScene("otracosaa");

    }








}

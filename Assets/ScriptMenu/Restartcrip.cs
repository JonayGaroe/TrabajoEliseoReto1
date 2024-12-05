using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restartcrip : MonoBehaviour
{
    [SerializeField]
    GameObject finalPartida;

    [SerializeField]
    GameObject QuitarMenuNivel;

    [SerializeField]
    GameObject empiezaPartida;

    bool estaJugando = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EmpezarJuego()
    {
        empiezaPartida.SetActive(false);
        if (estaJugando == false)
        {
            estaJugando = true;
            empiezaPartida.SetActive(false);

        }


    }

    public void Nivel1()
    {

        estaJugando = false;
        SceneManager.LoadScene("otraCosaa");
        finalPartida.SetActive(false);
        empiezaPartida.SetActive(false);


    }

    public void Nivel2()
    {

        estaJugando = false;
        SceneManager.LoadScene("SegundoNivel");
        finalPartida.SetActive(false);
        empiezaPartida.SetActive(false);


    }
    public void Nivel3()
    {

        estaJugando = false;
        //SceneManager.LoadScene("S");
        finalPartida.SetActive(false);
        empiezaPartida.SetActive(true);
        QuitarMenuNivel.SetActive(false);

    }

    public void Nivel4()
    {

        estaJugando = false;
     //   SceneManager.LoadScene("SegundoNivel");
        finalPartida.SetActive(false);
        empiezaPartida.SetActive(true);
        QuitarMenuNivel.SetActive(false);


    }


    public void Nivel5()
    {

        estaJugando = false;
      //  SceneManager.LoadScene("SegundoNivel");
        finalPartida.SetActive(false);
        empiezaPartida.SetActive(true);


    }


}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas2 : MonoBehaviour
{
    public static Vidas2 instance;
    public int vidaCube = 2;
    public int sumaPuntos = 500;
    public bool haGolpeado = false;
    // private GeneradorObstaculos generadorObstaculos;

    private void Awake()
    {
        
        if(instance = null)
        {
            instance = this;    


        }
        else
        {

            Destroy(gameObject);


        }

    }
    // Start is called before the first frame update
    void Start()
    {

        //generadorObstaculos = FindObjectOfType<GeneradorObtaculos>();

    }

    // Update is called once per frame
    void Update()
    {
        





    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Pelota")
        {
            vidaCube--;
            if(vidaCube == 0)
            {
                 //PuntosManager.Instance.SumarPuntos(sumaPuntos);
                //PuntosManager.Instance.RestarCubos();
                Destroy(gameObject);



            }





        }


    }




}

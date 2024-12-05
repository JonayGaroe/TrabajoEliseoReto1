using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasBloques : MonoBehaviour
{
    public int bloqueVida;
    // Start is called before the first frame update
    [SerializeField]
    GameObject powerup;


    void Start()
    {
        








    }

    void Update()
    {


    }
    private void OnCollisionEnter2D(Collision2D other)
    {

      
         float RandomI = Random.Range(0, 2) == 0 ? 1 : -1;
         Vector3 posicion = new Vector3(700, 400, 0);
         Instantiate(powerup, posicion, Quaternion.identity);
          

      



    }
}

        




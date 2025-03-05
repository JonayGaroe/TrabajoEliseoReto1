using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasBloques : MonoBehaviour
{
    public int bloqueVida;
    // Start is called before the first frame update
    public GameObject prefabPowerUp; // Prefab del power-up
    public float probabilidadPowerUp = 0.8f; // Probabilidad de que salga un power-up (20%)

    public delegate void BloqueDestruidoHandler();
    public event BloqueDestruidoHandler OnBloqueDestruido;



    void Start()
    {
        








    }

    void Update()
    {
        // Verifica si las vidas llegaron a 0
        if (bloqueVida <= 0)  // Cambiado de == 0 a <= 0
        {
            Debug.Log("Bloque destruido, instanciando power-up");
            if (Random.value < probabilidadPowerUp)
            {
                Debug.Log("Power-up instanciado en: " + transform.position);
                Instantiate(prefabPowerUp, transform.position, Quaternion.identity);
                Destroy(gameObject);  // Destruye el bloque
            }
        }
    }
    // Método para destruir el bloque
    public void DestruirBloque()
    {
        OnBloqueDestruido?.Invoke();  // Llama al evento cuando el bloque se destruye
        Destroy(gameObject); // Destruye el bloque
    }



}






















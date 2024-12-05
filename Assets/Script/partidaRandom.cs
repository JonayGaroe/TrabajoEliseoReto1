using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaAleatorio : MonoBehaviour
{
    public static MapaAleatorio instance;
    public GameObject[] prefabs; // Array para almacenar los diferentes prefabs (por ejemplo, suelos, paredes, etc.)
    public int anchoMapaMin = -820; // Ancho del mapa
    public int anchoMapaMax = 562; // Ancho del mapa
    public int altoMapaMin = -77; // Alto del mapa
    public int altoMapaMax = 264; // Alto del mapa

    public float distanciaEntreObjetosX = 80f; // Distancia entre cada prefab en el mapa
    public float distanciaEntreObjetosY = 50f; // Distancia entre cada prefab en el mapa
    public int filas = 6;
    public int columnas = 10;
    
    
    void Start()
    {
     
        GenerarMapa();

    }

    // Método para generar el mapa aleatorio
   public void GenerarMapa()
    {
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                float posicionX = anchoMapaMin + columna * distanciaEntreObjetosX;
                float posicionY = altoMapaMin + fila * distanciaEntreObjetosY;

                // Generar una posición aleatoria para el prefab
               Vector3 posicion = new Vector3(posicionX, posicionY,0);

                // Elegir un prefab aleatorio del array de prefabs
                GameObject prefabAleatorio = prefabs[Random.Range(0, prefabs.Length)];

                // Instanciar el prefab en la posición calculada
                Instantiate(prefabAleatorio, posicion, Quaternion.identity);
            }

        }

    }





}
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

    private int totalBloques; // Número total de bloques a generar
    private int bloquesRestantes; // Contador de bloques restantes


    private void Awake()
    {

    
        if (instance == null)
        {
            instance = this;

           

        }

    }

    void Start()
    {
        totalBloques = filas * columnas; // Calcular el total de bloques que se van a generar
        bloquesRestantes = totalBloques; // Inicializar el contador de bloques restantes
        GenerarMapa(); // Generar el mapa al inicio
    }


    public void Update()
    {

        if (bloquesRestantes <= 0)
        {
            // Si ya no quedan bloques, regenerar el mapa
            GenerarMapa();

        }

    }



    // Método para generar el mapa aleatorio
    public void GenerarMapa()
    {
        Debug.Log("Generando el mapa...");

        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                float posicionX = anchoMapaMin + columna * distanciaEntreObjetosX;
                float posicionY = altoMapaMin + fila * distanciaEntreObjetosY;

                // Generar una posición para el prefab
                Vector3 posicion = new Vector3(posicionX, posicionY, 0);

                // Elegir un prefab aleatorio del array de prefabs
                GameObject prefabAleatorio = prefabs[Random.Range(0, prefabs.Length)];

                // Instanciar el prefab en la posición calculada
                GameObject bloqueInstanciado = Instantiate(prefabAleatorio, posicion, Quaternion.identity);

                // Asegúrate de que el bloque pueda notificar cuando se destruya
                VidasBloques bloqueVida = bloqueInstanciado.GetComponent<VidasBloques>();
                if (bloqueVida != null)
                {
                    bloqueVida.OnBloqueDestruido += BloqueDestruido;
                }
            }
        }
    }

    // Método para regenerar el mapa cuando todos los bloques se destruyen
    public void RegenerarMapa()
    {
        Debug.Log("Regenerando el mapa...");

        // Destruir todos los objetos existentes (bloques)
        GameObject[] bloquesExistentes = GameObject.FindGameObjectsWithTag("bloquesss");
        foreach (GameObject bloque in bloquesExistentes)
        {
            Destroy(bloque);
        }

        // Volver a generar el mapa con los mismos parámetros
        GenerarMapa();
    }

    // Método que se llama cuando un bloque es destruido
    private void BloqueDestruido()
    {
        bloquesRestantes--; // Reducir el contador de bloques restantes
        Debug.Log("Bloques restantes: " + bloquesRestantes);  // Para comprobar el conteo de bloques restantes

        if (bloquesRestantes <= 0)
        {
            // Si ya no quedan bloques, regenerar el mapa
            RegenerarMapa();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuardadodePuntos : MonoBehaviour
{

    public int puntos;  // Puntos actuales
    public TextMeshProUGUI puntosText; // Cambia Text a TextMeshProUGUI puntosText;  // Referencia al UI de texto para mostrar los puntos
    public int puntosMaximos;  // Puntos máximos alcanzados

    // Start is called before the first frame update
    void Start()
    {

        // Cargar puntos y puntos máximos al inicio del juego
        CargarPuntos();


    }

    // Update is called once per frame
    void Update()
    {
        



    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;  // Aumenta los puntos actuales

        // Verificar si es el puntaje más alto alcanzado
        if (puntos > puntosMaximos)
        {
            puntosMaximos = puntos;  // Actualiza el puntaje máximo
            GuardarPuntosMaximos();  // Guarda el puntaje máximo
        }

        // Mostrar los puntos en la interfaz
        ActualizarTextoPuntos();
    }

    // Método para mostrar los puntos en el UI
    void ActualizarTextoPuntos()
    {
        puntosText.text = "Puntos: " + puntos.ToString();
    }

    // Método para guardar los puntos actuales
    public void GuardarPuntos()
    {
        PlayerPrefs.SetInt("Puntos", puntos);  // Guarda los puntos actuales
        PlayerPrefs.Save();  // Asegura que los cambios se guarden inmediatamente
    }

    // Método para cargar los puntos
    void CargarPuntos()
    {
        if (PlayerPrefs.HasKey("Puntos"))  // Si ya existe un valor guardado para "Puntos"
        {
            puntos = PlayerPrefs.GetInt("Puntos");  // Cargar los puntos guardados
        }

        if (PlayerPrefs.HasKey("PuntosMaximos"))  // Si existe un puntaje máximo guardado
        {
            puntosMaximos = PlayerPrefs.GetInt("PuntosMaximos");  // Cargar el puntaje máximo
        }

        // Actualizar los textos en la interfaz
        ActualizarTextoPuntos();
    }

    // Método para guardar los puntos máximos alcanzados
    public void GuardarPuntosMaximos()
    {
        PlayerPrefs.SetInt("PuntosMaximos", puntosMaximos);  // Guarda el puntaje máximo
        PlayerPrefs.Save();  // Guarda los cambios
    }

    // Método para borrar los puntos guardados
    public void BorrarPuntos()
    {
        PlayerPrefs.DeleteKey("Puntos");  // Borra los puntos actuales
        PlayerPrefs.DeleteKey("PuntosMaximos");  // Borra los puntos máximos
        PlayerPrefs.Save();  // Guarda los cambios


    }
}

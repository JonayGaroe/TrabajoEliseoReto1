using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDePuntos : MonoBehaviour
{

        // Instancia privada estática para el patrón Singleton
        private static SistemaDePuntos _instancia;

        // Diccionario para almacenar los bloques y sus puntos
        private Dictionary<string, int> bloques;

        // Constructor privado para evitar que se instancie fuera de la clase
        private SistemaDePuntos()
        {

            bloques = new Dictionary<string, int>();

        }

        // Método público para obtener la instancia única
        public static SistemaDePuntos ObtenerInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new SistemaDePuntos();
            }
            return _instancia;
        }

        // Asigna puntos a un bloque
        public void AsignarPuntos(string bloque, int puntos)
        {

            bloques[bloque] = puntos;

        }


        // Obtiene los puntos de un bloque
        public int ObtenerPuntos(string bloque)
        {

            return bloques.ContainsKey(bloque) ? bloques[bloque] : 0;

        }
 

    public class Program
    {
        public static void Main()
        {
            // Obtener la instancia del sistema de puntos (Singleton)
            SistemaDePuntos sistemaPuntos = SistemaDePuntos.ObtenerInstancia();

            // Asignamos puntos a los bloques
            sistemaPuntos.AsignarPuntos("bloque1", 100);
            sistemaPuntos.AsignarPuntos("bloque2", 200);
            sistemaPuntos.AsignarPuntos("bloque3", 300);

            // Mostramos los puntos de los bloques
            Console.WriteLine("Puntos del bloque1: " + sistemaPuntos.ObtenerPuntos("bloque1"));  // Salida: 100
            Console.WriteLine("Puntos del bloque2: " + sistemaPuntos.ObtenerPuntos("bloque2"));  // Salida: 200
            Console.WriteLine("Puntos del bloque3: " + sistemaPuntos.ObtenerPuntos("bloque3"));  // Salida: 300
            // Verificamos que solo hay una instancia
            SistemaDePuntos otraInstancia = SistemaDePuntos.ObtenerInstancia();
            Console.WriteLine("¿Es la misma instancia? " + (sistemaPuntos == otraInstancia));  // Salida: True

        }

    }

}
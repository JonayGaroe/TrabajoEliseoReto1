using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MuevetePalo : MonoBehaviour
{
    public MuevetePalo muevetePalo;  // Declaraci�n p�blica para asignar desde el Inspector

    [SerializeField] private float speed = 7f;
    [SerializeField] private float minX = 132f;
    [SerializeField] private float maxX = 980f;
    private Rigidbody2D paloRb;
    private bool isInverted = false;
    [SerializeField] private Vector2 positionPalo;

    float movement = 0f;

    private void Start()
    {
        paloRb = GetComponent<Rigidbody2D>();
        positionPalo = transform.localPosition;
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");  // Obtener movimiento horizontal

        if (isInverted)
        {
            movement *= -1; // Invertir el movimiento si est� activado
        }

        // Calcular la nueva posici�n en el eje X y limitarla a los valores de minX y maxX
        float newPosX = transform.position.x + movement * speed * Time.deltaTime;
        newPosX = Mathf.Clamp(newPosX, minX, maxX);  // Limitar el movimiento al rango establecido
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);






    }

    public void InvertirControles(float duration)
    {
        if (!isInverted) // Solo activar si no est� invertido ya
        {
            StartCoroutine(InvertirTemporizador(duration));
        }
    }

    private IEnumerator InvertirTemporizador(float duration)
    {
        isInverted = true;  // Activar la inversi�n de controles
        yield return new WaitForSeconds(duration);  // Esperar el tiempo de duraci�n
        isInverted = false; // Desactivar la inversi�n despu�s del tiempo
    }





public void ResetPlayer()
    {
        transform.position = positionPalo;
    }
}

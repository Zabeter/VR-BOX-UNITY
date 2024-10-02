using UnityEngine;

public class RotateAndFloat : MonoBehaviour
{
    // Velocidades p�blicas para ajustar desde el Inspector
    public float rotationSpeed = 100f; // Velocidad de rotaci�n
    public float floatSpeed = 2f;      // Velocidad de subir y bajar
    public float floatHeight = 2f;     // Altura m�xima a la que sube el objeto

    private float originalY;  // Posici�n original en el eje Y
    private bool goingUp = true;  // Para controlar la direcci�n de movimiento

    void Start()
    {
        // Almacenar la posici�n Y inicial del objeto
        originalY = transform.position.y;
    }

    void Update()
    {
        // Rotar el objeto alrededor del eje Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Movimiento de subir y bajar
        Vector3 position = transform.position;

        if (goingUp)
        {
            position.y += floatSpeed * Time.deltaTime;
            if (position.y >= originalY + floatHeight)
            {
                goingUp = false;  // Cambiar direcci�n cuando alcance la altura m�xima
            }
        }
        else
        {
            position.y -= floatSpeed * Time.deltaTime;
            if (position.y <= originalY)
            {
                goingUp = true;  // Cambiar direcci�n cuando alcance la altura original
            }
        }

        // Aplicar la nueva posici�n
        transform.position = position;
    }
}
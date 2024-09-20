using System.Collections;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float minHeight = 0.5f; // Altura m�nima a la que bajar� el c�rculo
    public float maxHeight = 2.0f; // Altura m�xima a la que subir� el c�rculo
    public float speedMax = 1.0f; // Velocidad del movimiento
    public float speedMin = 0.5f; // Velocidad m�nima del movimiento
    public float speed;
    public float height;
    //falta modificar la lista de colores si es que hace falta
    Color[] pastelColors = new Color[]
{
    new Color(0.82f, 0.95f, 0.76f), // Verde claro
    new Color(0.87f, 0.93f, 0.74f), // Lima suave
    new Color(0.89f, 0.94f, 0.81f), // Verde menta suave
    new Color(0.94f, 0.90f, 0.74f), // Amarillo pastel
    new Color(0.96f, 0.94f, 0.76f), // Amarillo vainilla
    new Color(0.94f, 0.84f, 0.77f), // Melocot�n suave
    new Color(0.95f, 0.88f, 0.79f), // Salm�n suave
    new Color(0.98f, 0.92f, 0.82f), // Naranja pastel claro
    new Color(0.96f, 0.79f, 0.76f), // Coral suave
    new Color(0.90f, 0.80f, 0.77f), // Rosa palo
    new Color(0.93f, 0.79f, 0.90f), // Lila suave
    new Color(0.94f, 0.85f, 0.92f), // Rosa pastel suave
    new Color(0.86f, 0.82f, 0.97f), // Lavanda claro
    new Color(0.83f, 0.85f, 0.97f), // Azul lavanda claro
    new Color(0.76f, 0.88f, 0.97f), // Celeste pastel
    new Color(0.77f, 0.91f, 0.93f), // Cian claro pastel
    new Color(0.75f, 0.92f, 0.89f), // Aguamarina suave
    new Color(0.81f, 0.92f, 0.89f), // Verde agua suave
    new Color(0.84f, 0.93f, 0.85f), // Verde musgo suave
    new Color(0.89f, 0.96f, 0.88f), // Verde
};
    int color = 0;

    private Vector3 initialPosition; // Guardar la posici�n original del c�rculo

    void Start()
    {
        color = Random.Range(0, pastelColors.Length);
        // Asignar un color aleatorio al c�rculo
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = pastelColors[color];

        // Guardar la posici�n original del c�rculo
        initialPosition = transform.position;

        // Iniciar el movimiento c�clico de subida y bajada constante
        StartCoroutine(MoveCircleConstantly());
    }

    IEnumerator MoveCircleConstantly()
    {
        while (true)
        {
            speed = Random.Range(speedMin, speedMax); // Velocidad aleatoria
            height = Random.Range(minHeight, maxHeight); // Altura aleatoria
            // Subir progresivamente a la altura m�xima
            yield return StartCoroutine(MoveToPosition(new Vector3(initialPosition.x, height, initialPosition.z)));

            // Bajar progresivamente a la altura m�nima
            yield return StartCoroutine(MoveToPosition(new Vector3(initialPosition.x, initialPosition.y, initialPosition.z)));
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        // Movimiento progresivo hacia la posici�n de destino
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            yield return null; // Esperar al siguiente frame
        }

        // Asegurarse de que la posici�n final sea exacta
        transform.position = targetPosition;
    }
}
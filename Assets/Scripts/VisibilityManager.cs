using UnityEngine;
using System.Collections.Generic; // Necesario para usar listas.

public class VisibilityManager : MonoBehaviour
{
    public Camera mainCamera; // Asigna tu c�mara desde el Inspector.
    private List<Renderer> espectadorRenderers = new List<Renderer>(); // Lista para almacenar los renderers de los espectadores.
    public float buffer = 0.1f; // Factor de expansi�n del frustum. 0.1f es un 10% extra.

    private void Awake()
    {
        // Encuentra todos los renderers y colliders con la etiqueta "Espectador" al inicio.
        GameObject[] espectadors = GameObject.FindGameObjectsWithTag("Espectador");
        foreach (GameObject espectador in espectadors)
        {
            Renderer renderer = espectador.GetComponent<Renderer>();

            if (renderer != null)
            {
                espectadorRenderers.Add(renderer);
            }
        }
    }

    void Update()
    {
        // Recorre los renderers en la lista para verificar si est�n en el frustum de la c�mara.
        for (int i = 0; i < espectadorRenderers.Count; i++)
        {
            Renderer renderer = espectadorRenderers[i];

            if (renderer != null) // Verifica que el renderer no sea nulo.
            {
                // Verificar si el objeto est� dentro del frustum de la c�mara expandido con buffer.
                if (IsVisibleFrom(renderer, mainCamera))
                {
                    // Activa el Renderer si est� visible, para que sea interactivo y visible.
                    renderer.enabled = true;
                }
                else
                {
                    // Desactiva solo el Renderer si no est� visible, para ocultar pero mantener la l�gica.
                    renderer.enabled = false;
                }
            }
        }
    }

    // Funci�n para verificar si el objeto es visible desde la c�mara con un buffer.
    bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

        // Expandimos el frustum aplicando el buffer a cada plano del frustum.
        for (int i = 0; i < planes.Length; i++)
        {
            planes[i].distance += buffer; // Aplicamos un peque�o desplazamiento en la distancia del plano.
        }

        // Verificamos si el bounding box del objeto est� dentro de los planos del frustum.
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}
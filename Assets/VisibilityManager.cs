using UnityEngine;
using System.Collections.Generic; // Necesario para usar listas.

public class VisibilityManager : MonoBehaviour
{
    public Camera mainCamera; // Asigna tu c�mara desde el Inspector.
    private List<Renderer> espectadorRenderers = new List<Renderer>(); // Lista para almacenar los renderers de los espectadores.
    private List<Collider> espectadorColliders = new List<Collider>(); // Lista para almacenar los colliders de los espectadores.

    private void Awake()
    {
        // Obt�n la c�mara si no est� asignada.
        if (mainCamera == null)
        {
            mainCamera = GetComponent<Camera>();
        }

        // Encuentra todos los renderers y colliders con la etiqueta "Espectador" al inicio.
        GameObject[] espectadors = GameObject.FindGameObjectsWithTag("Espectador");
        foreach (GameObject espectador in espectadors)
        {
            Renderer renderer = espectador.GetComponent<Renderer>();
            Collider collider = espectador.GetComponent<Collider>();

            if (renderer != null)
            {
                espectadorRenderers.Add(renderer);
            }

            if (collider != null)
            {
                espectadorColliders.Add(collider);
            }
        }
    }

    void Update()
    {
        // Recorre los renderers en la lista para verificar si est�n en el frustum de la c�mara.
        for (int i = 0; i < espectadorRenderers.Count; i++)
        {
            Renderer renderer = espectadorRenderers[i];
            Collider collider = espectadorColliders[i];

            if (renderer != null) // Verifica que el renderer no sea nulo.
            {
                // Verificar si el objeto est� dentro del frustum de la c�mara.
                if (IsVisibleFrom(renderer, mainCamera))
                {
                    // Activa el Renderer y Collider si est� visible, para que sea interactivo y visible.
                    renderer.enabled = true;
                    if (collider != null) collider.enabled = true;
                }
                else
                {
                    // Desactiva solo el Renderer y el Collider si no est� visible, para ocultar pero mantener la l�gica.
                    renderer.enabled = false;
                    if (collider != null) collider.enabled = false;
                }
            }
        }
    }

    // Funci�n para verificar si el objeto es visible desde la c�mara.
    bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}
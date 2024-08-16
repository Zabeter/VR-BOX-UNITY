using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    public GameObject PERSONAJE;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colision� es una mano
        Debug.Log("DETECCION");
            DetectarLado(other);
        
    }

    private void DetectarLado(Collider manoCollider)
    {
        Debug.Log("DETECCION 2");

        // Obt�n la posici�n del colisionador de la mano
        Vector3 manoPosition = manoCollider.transform.position;

        Debug.Log("DETECCION 3");
        // Calcula la direcci�n desde el personaje hacia la mano
        Vector3 direction = manoPosition - PERSONAJE.transform.position;
        Debug.Log("DETECCION 4");
        // Proyecta la direcci�n en el plano horizontal del personaje
        Vector3 projection = Vector3.ProjectOnPlane(direction, Vector3.up);
        Debug.Log("DETECCION 5");
        // Obtiene el �ngulo en relaci�n con el frente del personaje
        float angle = Vector3.SignedAngle(PERSONAJE.transform.forward, projection, Vector3.up);
        Debug.Log("DETECCION 6");
        // Determina el lado de la colisi�n basado en el �ngulo
        if (angle > 0)
        {
            Debug.Log("La mano colision� desde el lado derecho.");
        }
        else
        {
            Debug.Log("La mano colision� desde el lado izquierdo.");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colision� con el pu�o");
        // Chequea si el objeto que colision� es el pu�o
        if (collision.gameObject.CompareTag("GUANTES"))
        {
            DetectarLado(collision);
        }
    }

    private void DetectarLado(Collision collision)
    {
        // Obt�n la posici�n del punto de contacto m�s cercano
        ContactPoint contactPoint = collision.GetContact(0);
        Debug.Log("Punto de contacto: " + contactPoint.point);

        // Calcula la direcci�n de la colisi�n
        Vector3 direction = contactPoint.point - gameObject.transform.position;
        Debug.Log(direction.sqrMagnitude);

        // Proyecta la direcci�n en el plano horizontal del personaje
        Vector3 projection = Vector3.ProjectOnPlane(direction, Vector3.up);
        Debug.Log(projection.sqrMagnitude);

        // Obtiene el �ngulo en relaci�n con el frente del personaje
        float angle = Vector3.SignedAngle(gameObject.transform.forward, projection, Vector3.up);
        Debug.Log(angle);

        // Determina el lado de la colisi�n basado en el �ngulo
        if (angle > 0)
        {
            Debug.Log("La colisi�n provino del lado derecho.");
        }
        else
        {
            Debug.Log("La colisi�n provino del lado izquierdo.");
        }
    }
}

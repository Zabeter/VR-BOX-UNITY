using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionColision : MonoBehaviour
{
    public GameObject sweatParticlesPrefab;  // Prefab de las part�culas de sudor
    public float particleLifetime = 2.0f;    // Tiempo que duran las part�culas antes de destruirs
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fist"))  // Aseg�rate de que el pu�o tiene el tag "Fist"
        {
            // Obtener el punto de contacto aproximado usando la posici�n del otro objeto (pu�o)
            Vector3 contactPoint = other.ClosestPoint(transform.position);

            // Instanciar las part�culas en el punto de contacto
            GameObject particles = Instantiate(sweatParticlesPrefab, contactPoint, Quaternion.identity);

            // Destruir las part�culas despu�s de un tiempo
            Destroy(particles, particleLifetime);
            Debug.Log("Particle generada");
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
            
    //    }
    //}
}



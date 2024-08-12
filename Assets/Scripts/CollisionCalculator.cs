using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionCalculator : MonoBehaviour
{
    // El Collider del otro objeto con el que el Plane est� colisionando
    public Collider otherObjectCollider;
    float intersectionPercentagemax;
    public TMP_Text DA�O;
    // M�todo llamado cuando comienza la colisi�n

    private void OnTriggerStay(Collider other)
    {
        if (other == otherObjectCollider)
        {
            CalculateIntersectionPercentage();
        }
    }

    // M�todo para calcular el porcentaje de intersecci�n
    private void CalculateIntersectionPercentage()
    {
        // Obt�n los l�mites (Bounds) del Plane y del otro objeto
        Bounds planeBounds = GetComponent<Collider>().bounds;
        Bounds otherBounds = otherObjectCollider.bounds;

        // Comprueba si hay intersecci�n
        if (planeBounds.Intersects(otherBounds))
        {
            // Calcula la intersecci�n de los l�mites
            Bounds intersectionBounds = CalculateIntersectionBounds(planeBounds, otherBounds);

            // Calcula el �rea del Plane
            float planeArea = planeBounds.size.x * planeBounds.size.z;

            // Calcula el �rea de la intersecci�n
            float intersectionArea = intersectionBounds.size.x * intersectionBounds.size.z;

            // Calcula el porcentaje de intersecci�n
            float intersectionPercentage = (intersectionArea / planeArea) * 100f;

            // Muestra el resultado en la consola
            if (intersectionPercentage > intersectionPercentagemax)
            {
                intersectionPercentagemax = intersectionPercentage;
            }
        }
        else
        {
            Debug.Log("No hay intersecci�n entre el Plane y el otro objeto.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == otherObjectCollider)
        {
            Debug.Log("El porcentaje de intersecci�n m�ximo es: " + intersectionPercentagemax + "%");
            DA�O.text = "Da�o: " + intersectionPercentagemax;
            intersectionPercentagemax = 0;
        }
    }

    // M�todo para calcular los l�mites de la intersecci�n
    private Bounds CalculateIntersectionBounds(Bounds planeBounds, Bounds otherBounds)
    {
        Vector3 minPoint = Vector3.Max(planeBounds.min, otherBounds.min);
        Vector3 maxPoint = Vector3.Min(planeBounds.max, otherBounds.max);
        return new Bounds((minPoint + maxPoint) / 2, maxPoint - minPoint);
    }
}

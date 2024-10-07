using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CamaraScript : MonoBehaviour
{
    private Vector3 initialPosition;
    private float targetAspectRatio = 1.7777f;
    public float targetFOV = 60f;

    void Start()
    {
        // Guarda la posici�n inicial de la c�mara
        initialPosition = transform.position;
        Camera.main.aspect = targetAspectRatio;
        Camera.main.fieldOfView = targetFOV;
    }

    void LateUpdate()
    {
        // Mant�n la c�mara en la misma posici�n
        transform.position = initialPosition;
    }
}

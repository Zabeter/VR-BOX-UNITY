using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazosCollision : MonoBehaviour
{
    public HealthBarScript healthbar;
    public GameObject DERECHA;
    public GameObject IZQUIERDA;
    public GameObject FRENTE;
    public GameObject IZQUIERDAABAJO;
    public GameObject DERECHAABAJO;
    public GameObject BRAZODERECHO;
    public GameObject BRAZOIZQUIERDO;
    public GameObject PU�ODERECHO;
    public GameObject PU�OIZQUIERDO;
    // Start is called before the first frame update
    void Start()
    {
        //FALTA PONERLE COLISION AL BRAZO (OSEA EL BRAZO EXIT HITBOX)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BRAZO IZQUIERDO")
        {
            Debug.Log("Colision con brazo izquierdo");
            DeactivateAll();
            healthbar.hp -= 2;
        }
        else if (other.gameObject.name == "BRAZO DERECHO")
        {
            Debug.Log("Colision con brazo derecho");
            DeactivateAll();
            healthbar.hp -= 2;
        }
        else if (other.gameObject.name == "PU�O IZQUIERDO")
        {
            Debug.Log("Colision con pu�o izquierdo");
            DeactivateAll();
            healthbar.hp -= 2;
        }
        else if (other.gameObject.name == "PU�O DERECHO")
        {
            Debug.Log("Colision con pu�o derecho");
            DeactivateAll();
            healthbar.hp -= 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "Brazos Exit HitBox")
        {
            ActivateAll();
        }
    }

    private void DeactivateAll()
    {
        IZQUIERDA.layer = 6;
        DERECHA.layer = 6;
        FRENTE.layer = 6;
        DERECHAABAJO.layer = 6;
        IZQUIERDAABAJO.layer = 6;
        BRAZODERECHO.layer = 6;
        BRAZOIZQUIERDO.layer = 6;
    }
    private void ActivateAll()
    {
        IZQUIERDA.layer = 8;
        DERECHA.layer = 8;
        FRENTE.layer = 8;
        DERECHAABAJO.layer = 8;
        IZQUIERDAABAJO.layer = 8;
        BRAZODERECHO.layer = 8;
        BRAZOIZQUIERDO.layer = 8;
    }
}

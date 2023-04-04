using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Trigger: un objeto desde fuera entra en colision con el objeto en cuestion.
    private void OnTriggerEnter(Collider other)
    {
        //Si el otro objeto contiene la etiqueta "Projectile"
        if (other.CompareTag("Projectile")) {
            
            // Que destruya los objetos:
            Destroy(this.gameObject); // - Destruye el animal

            Destroy(other.gameObject); // - Destruye el proyectil
        }
        
    }

}

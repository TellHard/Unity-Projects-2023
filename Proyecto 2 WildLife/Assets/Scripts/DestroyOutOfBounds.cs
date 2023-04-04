using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //Script que permite borrar gameObject de la pantalla una vez cruza fronteras
    //{topBound o botBound} con (transform.position)

    private float topBound = 30f;
    private float botBound = -15f;
    
    void Update()
    {
        // Si el objeto pasa de la posicion 30 en Z se destruye (top)
        if (this.transform.position.z > topBound) {
            Destroy(gameObject);
        }

        // Si el objeto pasa de la posicion -15 en Z se destruye (bottom)
        if (this.transform.position.z < botBound) {

            Debug.Log("Game Over :(");
            Destroy(gameObject);

            // Congela el juego (Game Over)
            Time.timeScale = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10.0f;

    [Tooltip("Valor maximo en el que se podra mover el personaje")]
    public float xRange = 15.0f;


    public GameObject projectilePrefab;

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Limite hacia la izquierda
        if (transform.position.x < -xRange)
        {

            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }

        // Limite hacia la derecha
        if (transform.position.x > xRange)
        {

            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }


        // Acciones que realiza el personaje
        if (Input.GetKeyDown(KeyCode.Space)) { 
            
            //Lanzar proyectil con el espacio
            // "Instantiate" permite generar un GameObject previamente definido
            Instantiate(projectilePrefab, this.transform.position, projectilePrefab.transform.rotation);
        
        }

    }
}

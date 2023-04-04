using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 5.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // Adelante
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
        }

        // Atras
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * playerSpeed);
        }

        // Movimiento Horizontal
        if (Input.GetKey(KeyCode.D)) { 
            transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
        }
        
    }
}

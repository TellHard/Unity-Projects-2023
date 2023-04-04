using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float speed = 10;
    public float rotationSpeed = 180;
    void Start()
    {
        
    }

    void Update()
    {
        // Mover objeto a la izquierda
        transform.localPosition += Vector3.left * speed * Time.deltaTime;

        // Rotar el objeto
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

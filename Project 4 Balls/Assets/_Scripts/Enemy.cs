using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidBody;
    public float moveForce = 1f;

    private GameObject player;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        //Declaramos que player = al GameObject que se llama "Player"
        player = GameObject.Find("Player");
}
    
    void Update()
    {
        // Posicion de destino (posicion del player) - posicion de origen (posicion del enemigo[this])
        // Normalizamos el vector con .normalized (Hace que el vector tenga siempre magnitud 1)
        Vector3 direction = (player.transform.position - this.transform.position).normalized;
        _rigidBody.AddForce(direction * moveForce);

        if (this.transform.position.y < -30) { 
            Destroy(this.gameObject);
        }

    }
}

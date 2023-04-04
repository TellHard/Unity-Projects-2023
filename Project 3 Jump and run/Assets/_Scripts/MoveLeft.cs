using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5.0f;

    private PlayerController playerController; //Declaramos variable tipo PlayerController (Script Externo)

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //Devuelve el GameObject que se llama "Player" y de el saca el componente PlayerController (Script)
    }

    void Update()
    {
        // Si gameOver no es true sigue deplazandose a la izquierda
        if (!playerController.gameOver == true)
        {
            // Mover a la izquierda Direction*Velocity*Time
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}

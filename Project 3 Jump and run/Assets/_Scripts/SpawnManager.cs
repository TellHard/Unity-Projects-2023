using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacle;
    private float tiempoInicial = 3.0f;
    private float tiempoSecuencial = 2.0f;

    private PlayerController playerController;

    void Start()
    {
        //Llama a la funcion spawnObstacle, con un tiempo de carga inicial y un tiempo base de spawn
        InvokeRepeating("spawnObstacle", tiempoInicial, tiempoSecuencial);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //Devuelve el GameObject que se llama "Player" y de el saca el componente PlayerController (Script)
    }


    void Update()
    {
        
    }

    void spawnObstacle() {
        // Si gameOver no es true
        if (!playerController.gameOver == true) {
            Instantiate(obstacle[Random.Range(0, obstacle.Length)]);
            // Instancia objetos
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] enemies;
    private int animalIndex;


    private float spawnRangeX = 15f;
    private float spawnPositionZ;

    [SerializeField, Range(1,5), Tooltip("Intervalo de inicio del juego en segundos ")]
    private float startDelay = 2f;

    [SerializeField, Range(0, 3), Tooltip("Intervalo de spawn de animales en segundos ")]
    private float spawnInterval = 1.5f;

    private void Start()
    {
        spawnPositionZ = this.transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {

        // Random.Range permite generar un numero entre un rango dado (spawnRangeX)

        float XRandom = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnPosition = new Vector3(XRandom, 0, spawnPositionZ);


        // Spawn de animales aleatorios
        animalIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies[animalIndex], spawnPosition, enemies[animalIndex].transform.rotation);
    }
}

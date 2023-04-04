using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 9f;

    [SerializeField]
    private int enemyCount;
    [SerializeField]
    private int powerUpCount;
    [SerializeField]
    private int enemyWave = 1;

    void Start()
    {
        //Llamo a la funcion SpawnEnemyWave y le paso por argumento el numero de enemigos a spawnear
        SpawnEnemyWave(enemyWave);
    }

    private void Update()
    {
        //Numero de gameObjects enemigos que hay en pantalla
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        //Numero de gameObjects powerUps que hay en pantalla
        powerUpCount = GameObject.FindGameObjectsWithTag("PowerUp").Length;

        //Si hay 0 que spawnee mas enemigos
        if (enemyCount == 0) 
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
        }

        //Al inicio de cada ronda spawnee un PowerUp
        if (powerUpCount == 0 && enemyCount == 0)
        {
            SpawnPowerUpWave();
        }
    }

    private Vector3 GenerateSpawnPosition() {

        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        //Posicion aleatoria con spawnPositionX y spawnPositionZ
        Vector3 randomPos = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPos;
    }

    //Metodo que permitira spawnear oleadas de enemigos
    private void SpawnEnemyWave(int numberOfEnemies) { 
    
        //Bucle for que permite spawnear enemigos
        for(int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
    
    }

    private void SpawnPowerUpWave()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }
}

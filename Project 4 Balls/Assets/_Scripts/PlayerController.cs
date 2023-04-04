using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    public float moveForce = 3f;
    public float powerUpForce = 500f;
    public GameObject focalPoint;

    public bool hasPowerUp;

    private float powerUpTimeIndicator1 = 4f;
    private float powerUpTimeIndicator2 = 4f;
    private float powerUpTimeIndicator3 = 2f;

    public GameObject[] powerUpIndicators;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        //focalPoint.transform.forward la pelota irá entorno a la posicion forward del focalPoint
        _rigidBody.AddForce(focalPoint.transform.forward * moveForce * verticalInput);

        // Con el for each decimos que indicator se refiere a los powerUpIndicators que hemos añadido
        // le decimos que su posicion va a ser la misma que la del player, al estar en un update se actualizará.
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position;

        }

        if (this.transform.position.y < -30) {
            SceneManager.LoadScene("Prototype 4");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")) { 
            hasPowerUp = true;
            Destroy(other.gameObject);

            //Arrancamos la corutina "PowerUpCountDown"
            StartCoroutine(PowerUpCountDown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp == true && collision.gameObject.CompareTag("Enemy")) {
            // Accedo al RB del enemigo
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;

            // Añado fuerza de impulso contra el enemigo
            enemyRigidBody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }

    //CORUTINA de que se quite el efecto del powerUp tras pasado "powerUpTime"
    IEnumerator PowerUpCountDown() {

        //Del array de powerUpIndicators posicion 0 lo activamos para que sea visible
        powerUpIndicators[0].gameObject.SetActive(true);

        yield return new WaitForSeconds(powerUpTimeIndicator1);
        //Desactivamos powerUpIndicators posicion 0 pasados los segundos
        powerUpIndicators[0].gameObject.SetActive(false);
        powerUpIndicators[1].gameObject.SetActive(true);

        yield return new WaitForSeconds(powerUpTimeIndicator2);
        powerUpIndicators[1].gameObject.SetActive(false);
        powerUpIndicators[2].gameObject.SetActive(true);

        yield return new WaitForSeconds(powerUpTimeIndicator3);
        powerUpIndicators[2].gameObject.SetActive(false);
        hasPowerUp = false;
    }
}

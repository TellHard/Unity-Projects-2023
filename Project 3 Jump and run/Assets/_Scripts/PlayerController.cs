using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))] // Crea dependencia (requiere RigidBody)
[RequireComponent(typeof(Collider))]   // Crea dependencia (requiere Collider)
public class PlayerController : MonoBehaviour
{
    //VARIABLES
    private Rigidbody playerRb; //playerRb se declara como tipo RigidBody
    public float jumpForce = 10.0f;
    public float gravityMultiplier; // Multiplicador de gravedad en el motor de fisicas

    private Boolean isOnGround = true;

    // _gameOver privado
    private bool _gameOver = false;

    //Getter del gameover para scripts externos
    public bool gameOver { get => _gameOver; }

    private float speedMultiplier = 1f;

    private Animator _animator;

    public ParticleSystem explosion;
    public ParticleSystem trail;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource _audioSource;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // playerRb obtiene el componente RigidBody
        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);

        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed_f", 1);
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        speedMultiplier = Time.deltaTime / 50 + 1;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            checkIsOnGround();
        }

        _animator.SetFloat("Speed Multiplier", speedMultiplier);
    }

    private void checkIsOnGround() {

        if (isOnGround == true && gameOver != true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Añade una fuerza hacia arriba que permite saltar (accediendo a rigidbody)
            isOnGround = false;
            _animator.SetTrigger("Jump_trig");
            trail.Stop();
            _audioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            trail.Play();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.LogWarning("Game Over :(");
            explosion.Play();
            trail.Stop();
            _audioSource.PlayOneShot(crashSound);
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            Invoke("RestartGame", 2);
        }
    }

    void RestartGame() {
        speedMultiplier = 1;
        
        SceneManager.LoadScene("Prototype 3");
    }
}

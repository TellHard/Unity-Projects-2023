using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    Vector3 posicionaAtras;
    void Start()
    {
        
    }

    
    void Update()
    {
        posicionaAtras = new Vector3(0,4,-5);
        this.transform.position = Player.transform.position + posicionaAtras;
    }
}

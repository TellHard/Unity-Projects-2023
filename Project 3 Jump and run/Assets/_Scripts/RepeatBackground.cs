using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatSize;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        repeatSize = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x - this.transform.position.x > repeatSize) { 
        transform.position = startPos;
        }
    }
}

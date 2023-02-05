using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1f;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    
    void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
    }
}

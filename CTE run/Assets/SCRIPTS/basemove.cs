using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basemove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0f, 0f);
    }
}

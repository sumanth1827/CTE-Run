using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    Rigidbody rb;
    Animator anim2;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim2 = GameObject.Find("Canvas").GetComponent<Animator>();
        
    }

    
    void FixedUpdate()
    {
        rb.velocity = new Vector3(GetComponentInParent<spawner>().speeds, 0f, 0f);
    }
    private void OnTriggerEnter(Collider ci)
    {
        if(ci.tag == "Player")
        {
            ci.GetComponentInChildren<Animator>().SetBool("die", true);
            GetComponentInParent<spawner>().speeds = 0f;
            anim2.SetBool("death", true);
            GetComponentInParent<spawner>().spawns = false;
        }
    }
}

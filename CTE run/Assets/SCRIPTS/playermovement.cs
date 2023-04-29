using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed=10f;
    private Rigidbody rb;
    private bool grounded = true;
    public float height = 3f;
    public float jumpspeed = 20f;
    public Animator anim;
    public AudioSource jumps;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        
    }

    
    void FixedUpdate()
    {
        Vector3 tmpos = transform.position;
        tmpos.z = Mathf.Clamp(transform.position.z, -3f, 3f); //we are not letting the z position go beyond our lane.
        transform.position = tmpos;
        
        if(Input.GetKey("a")) 
        {
            
            
            rb.velocity = new Vector3(0f, rb.velocity.y, -speed);
            

        }
        else if(Input.GetKey("d"))
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, speed);
            

        }


        if(!Input.GetKey("a") && !Input.GetKey("d"))
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            
        }
    }
    private void Update()
    {
        anim.SetFloat("x", Input.GetAxis("Horizontal"));
        if(Input.GetKeyDown("space") && grounded) //we make sure we can jump only if we are already on the ground. This prevents double jumps
        {
            jumps.Play();
            anim.SetBool("jump", true);
            rb.velocity = new Vector3(rb.velocity.x, jumpspeed, 0) ;
            grounded = false;
        }
        if(transform.position.y >= height && !grounded)//we set a certain height to which our player can jump
        {
            
            rb.velocity = new Vector3(rb.velocity.x, 0f, 0);
        }
        if(rb.velocity.y == 0)//when the player reaches the ground again, our y velocity is 0. Now we should be able to jump again
        {
            anim.SetBool("jump", false);
            grounded = true;
        }
        
    }
}

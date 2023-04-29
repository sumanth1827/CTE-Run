using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basespawner : MonoBehaviour
{
    [SerializeField] GameObject bases;
    [SerializeField] GameObject spawner,lco;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "base")
        {
            Instantiate(bases, lco.transform.position, bases.transform.rotation, spawner.transform);
        }
    }

}

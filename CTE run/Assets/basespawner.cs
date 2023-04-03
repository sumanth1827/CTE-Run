using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basespawner : MonoBehaviour
{
    [SerializeField] GameObject bases;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        Instantiate(bases, bases.transform.position, bases.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        //as soon as our obstacles collide, we destroy it.
    }
}

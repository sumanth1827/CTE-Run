using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private float t = 0f;
    public GameObject[] obj;
    private int rand;
    int prevrand = -1;
    public bool spawns = true;
    public float speeds = 15f;
    void Update()
    {
        t += Time.deltaTime;  //Start a timer
 
        if (t>=1.5 && spawns)     
        {
            rand = Random.Range(0, obj.Length); //To randomly choose an object in our array of obstacles
            while(rand == prevrand)
            {
                rand = Random.Range(0, obj.Length);
            }
            prevrand = rand;
            if (obj[rand].tag == "mid")
            {
                //The instantiate function spawns an object in a specified position and orientation. 
                //HERE THE OBJECT THAT DOES NOT REQUIRE A RANDOM LOCATION TO SPAWN IS TAGGED TO MID.
                Instantiate(obj[rand], new Vector3(transform.position.x, obj[rand].transform.position.y, obj[rand].transform.position.z), transform.rotation,transform.transform);
            }
            else
            {
                Instantiate(obj[rand], new Vector3(transform.position.x, obj[rand].transform.position.y, Random.Range(-3f, 0f)), transform.rotation, transform.transform);
                Instantiate(obj[rand], new Vector3(transform.position.x, obj[rand].transform.position.y, Random.Range(0f, 3f)), transform.rotation, transform.transform);
            }
            t = 0f; //we want to run this loop every 1.5s. Hence we reset the time to 0 and start the timer again every 1.5s
        }
    }
}

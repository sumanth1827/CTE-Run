using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawner : MonoBehaviour
{
    private float t = 0f;
    public GameObject[] obj;
    private int rand;
    int prevrand = -1;
    public bool spawns = true;
    public float speeds = 7f;

    public int score = 0;
    float scoretime = 0f;
    public TMP_Text score_text;
    private void Start()
    {
        StartCoroutine(spawnspeed());
    }
    void Update()
    {
        t += Time.deltaTime;  //Start a timer
        
        if (t>=4 && spawns)     
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
                Instantiate(obj[rand], new Vector3(transform.position.x, obj[rand].transform.position.y, obj[rand].transform.position.z), obj[rand].transform.rotation,transform.transform);
            }
            else
            {
                Instantiate(obj[rand], new Vector3(transform.position.x, obj[rand].transform.position.y, Random.Range(-3f, 0f)), transform.rotation, transform.transform);
                Instantiate(obj[rand], new Vector3(transform.position.x, obj[rand].transform.position.y, Random.Range(0f, 3f)), transform.rotation, transform.transform);
            }
            t = 0f; //we want to run this loop every 1.5s. Hence we reset the time to 0 and start the timer again every 1.5s
        }
        scoretime += Time.deltaTime;
        score = (int)(speeds * scoretime);
        if(score!=0)
        {
            score_text.text = score.ToString();
        }
        


    }
    public IEnumerator spawnspeed()
    {
    while(speeds!=0f)
        {

            yield return new WaitForSeconds(7f);
            if (speeds == 0)
            {
                break;
            }
            speeds += 3f;


            if(speeds > 30f)
            {
                yield break;
            }
        }

    }
}

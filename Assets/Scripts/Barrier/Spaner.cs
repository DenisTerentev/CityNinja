using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaner : MonoBehaviour
{
    public GameObject box;
    public GameObject enemy;
    private float TimeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    private void Update()
    {
        if(TimeBtwSpawn<=0)
        {
            Vector2 pos = new Vector2((float)37.46,(float) -2.5);
            Vector2 pos2 = new Vector2((float)17.46,(float) 2.5);
            Instantiate(box, pos, Quaternion.identity);
            Instantiate(enemy, pos2, Quaternion.identity);
            TimeBtwSpawn = startTimeBtwSpawn;
            if(startTimeBtwSpawn>minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            TimeBtwSpawn -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaner : MonoBehaviour
{
    public GameObject box;
    public GameObject box2;
    public GameObject enemy;
    public GameObject shuriken;
    private float TimeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    private void Update()
    {
        if(TimeBtwSpawn<=0)
        {
            Vector2 posBox = new Vector2((float)39.46,(float) -2.5);
            Vector2 posEnemy = new Vector2((float)17.46,(float) 2.5);
            Vector2 posShuriken = new Vector2((float)40.46, Random.Range((float)-2.5, (float)3.4));
            Vector2 posBox2 = new Vector2((float)42.46, (float)-1.2);

            if (Random.Range(1,4)==1) Instantiate(box, posBox, Quaternion.identity);
            else Instantiate(box2, posBox2, Quaternion.identity);

            Instantiate(enemy, posEnemy, Quaternion.identity);

            if (Random.Range(1,3)==1) Instantiate(shuriken, posShuriken, Quaternion.identity);
            

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hend : MonoBehaviour
{
    public GameObject shuriken;
    public Transform pointPlace;

    private float timeBtwShoots;
    public float startTimeBtwShoots;

    void Update()
    {
        if (timeBtwShoots <= 0)
        {
            if (Input.GetMouseButton(1))
            {
                Instantiate(shuriken, pointPlace.position, pointPlace.rotation);
                timeBtwShoots = startTimeBtwShoots;
            }
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}

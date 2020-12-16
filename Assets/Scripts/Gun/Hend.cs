using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hend : MonoBehaviour
{
    public GameObject shuriken;
    public Transform pointPlace;
    

    private float timeBtwShoots;
    public float startTimeBtwShoots;

    private Inventory inventory;

    private bool isCliccedShuriken;

    public GameObject sound;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (timeBtwShoots <= 0 && inventory.CanUse())
        {
            if (isCliccedShuriken)
            {
                Instantiate(shuriken, pointPlace.position, pointPlace.rotation);
                Instantiate(sound, transform.position, Quaternion.identity);
                timeBtwShoots = startTimeBtwShoots;
                inventory.slots[inventory.LastSlot()].CloseSlot();
                isCliccedShuriken = false;
            }
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
            isCliccedShuriken = false;
        }
    }
    public void ClickedShuriken()
    {
        isCliccedShuriken = true;
    }
}

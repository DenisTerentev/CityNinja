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

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (timeBtwShoots <= 0 && inventory.CanUse())
        {
            //Input.GetMouseButton(1)
            if (isCliccedShuriken)
            {
                Instantiate(shuriken, pointPlace.position, pointPlace.rotation);
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

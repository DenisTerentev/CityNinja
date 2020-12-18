using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;

    public float speed;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        transform.Translate(Vector2.left * speed*Time.timeScale);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            for(int i =0; i<inventory.slots.Length;i++)
            {
                if(inventory.isFull[i]==false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(slotButton, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}

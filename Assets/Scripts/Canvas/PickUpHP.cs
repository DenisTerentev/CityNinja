using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHP : MonoBehaviour
{
    public float speed;
    private int hp = 1;
    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.TakeHP(hp);
            Destroy(gameObject);
        }
    }
}

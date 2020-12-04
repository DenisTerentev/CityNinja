using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public Animator anim;
    public float speed;
    public GameObject effect;
    public float distance;

    public Transform seePoint;
  

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(seePoint.transform.position, seePoint.transform.right, distance);
        if(hit.collider?.gameObject.GetComponent<Player>())
        {
            print("вижу");
        }
        else
        {
            transform.Translate(Vector2.left * speed);
            print("не вижу");
        }
    }

    public int TakeDamage(int damage)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        health -= damage;
        if (health <= 0) Destroy(gameObject);
        return health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBarrier : MonoBehaviour
{
    public int damage=1;
    public float speed;
    public GameObject effect;

    private void Update()
    {
        transform.Translate(Vector2.left * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //other.GetComponent<Player>().health -= damage;
            other.GetComponent<Player>().TakeDamage(damage);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}

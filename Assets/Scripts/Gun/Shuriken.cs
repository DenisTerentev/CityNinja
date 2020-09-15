using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public Transform shootPoint;
    private float timeBtwShoots;
    public float startTimeBtwShoots;

    
    private void Update()
    {



        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider!=null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                //hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject, lifetime);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


}

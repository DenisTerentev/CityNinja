using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    private Score score;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }
  
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider!=null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                score.AddScore(damage);
                Destroy(gameObject);
            }
            else if (hitInfo.collider.CompareTag("Box"))
            {
                hitInfo.collider.GetComponent<BoxBarrier>().TakeDamage(damage);
                score.AddScore(damage);
                Destroy(gameObject);
            }
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        


    }
    public void DestroyShuriken()
    {
        Destroy(gameObject);
    }
}

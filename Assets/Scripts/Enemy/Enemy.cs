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

    public Transform attackPos;
    public LayerMask playerMask;
    public float attackRange;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public GameObject laughSound;
    public GameObject takeDamageSound;
    public GameObject swordSound;

  

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(seePoint.transform.position, seePoint.transform.right, distance);
        if(hit.collider?.gameObject.GetComponent<Player>())
        {
            if(timeBtwAttack<=0)
            {
                anim.SetTrigger("Attack");
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed*Time.timeScale);
        }
    }

    public int TakeDamage(int damage)
    {
        Instantiate(takeDamageSound, transform.position, Quaternion.identity);
        Instantiate(effect, transform.position, Quaternion.identity);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
            
        return health;
    }

    public void EnemyAttack()
    {
        Instantiate(swordSound, transform.position, Quaternion.identity);
        Collider2D[] enemes = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerMask);
        for(int i=0;i<enemes.Length;i++)
        {
            enemes[i].GetComponent<Player>()?.TakeDamage(damage);
            enemes[i].GetComponent<BoxBarrier>()?.TakeDamage(damage);
        }
        Instantiate(laughSound, transform.position, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;

    private bool isClikkedSword;
    public Score score;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }
  
    private void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (isClikkedSword)
            {
                anim.SetTrigger("Attack");
                timeBtwAttack = startTimeBtwAttack;
                isClikkedSword = false;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            isClikkedSword = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    public void OnAttack()//будет вызываться из аниматора
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<Enemy>())
            {
                enemies[i].GetComponent<Enemy>()?.TakeDamage(damage);
                score.AddScore(damage);
                break;
            }
            else if (enemies[i].GetComponent<BoxBarrier>())
            {
                enemies[i].GetComponent<BoxBarrier>()?.TakeDamage(damage);
                score.AddScore(damage);
                break;
            }
            
        }
    }

    public void SwordClickedButton()
    {
        isClikkedSword = true;
    }
}

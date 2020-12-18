﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBarrier : MonoBehaviour
{
    public int damage=1;
    public float speed;
    public GameObject effect;
    public int health;
    public GameObject hardHP;

    public GameObject boxSound;

    private void Update()
    {
        transform.Translate(Vector2.left * speed*Time.timeScale);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(boxSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {

            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Enemy>().TakeDamage(damage);
            Instantiate(boxSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public int TakeDamage(int damage)
    {
        Instantiate(boxSound, transform.position, Quaternion.identity);
        Instantiate(effect, transform.position, Quaternion.identity);
        health -= damage;
        if (health <= 0)
        {
            if(Random.Range(1,5)==1) Instantiate(hardHP, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        return health;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed;
    //public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider!=null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                //hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("Box"))
            {
                hitInfo.collider.GetComponent<BoxBarrier>().TakeDamage();
                Destroy(gameObject);
            }
            //Destroy(gameObject, lifetime);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //this.transform.Rotate(0, 0, 2.0f);
        //transform.Rotate(Vector3.fwd, 360 * Time.deltaTime, Space.Self);// не получаеься сделать вращение вокруг своей оси


    }
    public void DestroyShuriken()
    {
        Destroy(gameObject);
    }
}

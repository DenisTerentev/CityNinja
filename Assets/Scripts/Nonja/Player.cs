using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 5;
    private bool isGround;
    public Transform feetPos;
    public float checkRadeus;
    public LayerMask whatIsGround;
    public float jumpForse;
    private bool isClicked;
    public float speed;

    private Rigidbody2D rb;
    private Animator animator;

    public GameObject effect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckPosition(transform.position.x);
        if (health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        isGround = Physics2D.OverlapCircle(feetPos.position, checkRadeus, whatIsGround);
        if(isGround && isClicked)
        {
            rb.velocity = Vector2.up * jumpForse;
            isClicked = false;
            animator.SetTrigger("TakeOff");
           
        }
        else
        {
            isClicked = false;
        }
        if(isGround)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }
    public void CheckPosition(float x)
    {
        if (x <= -2.7) transform.Translate(Vector2.right * speed);
    }
    public void JumpButton()
    {
        isClicked = true;
    }
    public int TakeDamage(int damage)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        health -= damage;
        return health;
    }

}

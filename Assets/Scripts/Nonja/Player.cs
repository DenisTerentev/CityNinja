using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health;
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

    public GameObject musicSound;
    public GameObject takeDamageSound;
    public GameObject jumpSound;

    private Animator camAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Instantiate(musicSound, transform.position, Quaternion.identity);
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    private void Update()
    {
        CheckPosition(transform.position.x);
        if (health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        isGround = Physics2D.OverlapCircle(feetPos.position, checkRadeus, whatIsGround);
        if(isGround && isClicked)
        {
            Instantiate(jumpSound, transform.position, Quaternion.identity);
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
        if (x <= -2.7) transform.Translate(Vector2.right * speed*Time.timeScale);
    }
    public void JumpButton()
    {
        isClicked = true;
    }
    public int TakeDamage(int damage)
    {
        Instantiate(takeDamageSound, transform.position, Quaternion.identity);
        Instantiate(effect, transform.position, Quaternion.identity);
        health -= damage;
        camAnim.SetTrigger("Shake");
        return health;
    }

    public int TakeHP(int hp)
    {
        health += hp;
        return health;
    }

}

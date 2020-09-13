using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool isGround;
    public Transform feetPos;
    public float checkRadeus;
    public LayerMask whatIsGround;
    public float jumpForse;
    private bool isClicked;

    private Rigidbody2D rb;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
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
    public void JumpButton()
    {
        isClicked = true;
    }

}

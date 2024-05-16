using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    Animator animator;
     float verticalMove = 0f;
    [SerializeField] public Rigidbody2D rigb;
 
    void Start()
    {
        animator = GetComponent<Animator>();
        rigb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        
        verticalMove = Input.GetAxisRaw("Vertical") * 3f;
        animator.SetFloat("verticalSpeed", Mathf.Abs(verticalMove));
        if (Input.GetAxisRaw("Horizontal") ==1||Input.GetAxisRaw("Horizontal")==-1)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (animator.GetBool("isJumping") && (Mathf.Approximately(rigb.velocity.y, 0f)))
        {
            animator.SetBool("isJumping", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping",true);
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ladders"))
        {
            animator.SetBool("isClimbing", true);
            animator.SetBool("isJumping", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladders"))
        {
            animator.SetBool("isClimbing", false); 
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ladders"))
        {
            animator.SetBool("isJumping", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            animator.SetBool("isDeath", true);
            GetComponent<playerController>().player_die();
        }
    }
    
}

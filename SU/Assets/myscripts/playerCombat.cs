using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    soundController soundController;
    
    private void Start()
    {
        soundController = GetComponent<soundController>();
      
    }

    void Update()
    {
        
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Attack();
               
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
    void Attack()
    {

        soundController.playAttackSound();
        animator.SetTrigger("isAttacking");
        animator.SetBool("isJumping",false);
        Collider2D[] hit =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hit)
        {
            enemy.GetComponent<enemyController>().TakeDamage(1);
        }   
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    

}

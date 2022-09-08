using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform AttackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            LightAttack();
        } else
            if (Input.GetKeyDown(KeyCode.K)) {
            MediumAttack();
        } else
            if(Input.GetKeyDown(KeyCode.L)) {
            HeavyAttack();
        }
            
        
    }


    void LightAttack() {
        animator.SetTrigger("AttackL");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    private void MediumAttack() {
        animator.SetTrigger("AttackM");
    }

    private void HeavyAttack() {
        animator.SetTrigger("AttackH");
    }

    private void OnDrawGizmosSelected() {
        if(AttackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

}

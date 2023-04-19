using EthanTheHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    bool coolDown = false;

    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int damage = 5;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !coolDown)
        {
            
            StartCoroutine(wait());

        }
        
    }
    void Attack()
    {
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamge(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator wait()
    {
        Attack();
        coolDown = true;
        yield return new WaitForSeconds(1);
        coolDown = false;
    }
}

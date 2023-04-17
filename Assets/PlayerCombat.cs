using EthanTheHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        anim.SetTrigger("attack");

        Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
    }

}

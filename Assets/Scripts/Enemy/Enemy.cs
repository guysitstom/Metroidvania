using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator anim;
    [SerializeField] Animator Gate;
    void Start()
    {
        currentHealth = maxHealth;
        
    }

  
    public void TakeDamge(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hurt");
        if(currentHealth <=0)
        {
            Die();
        }
        void Die()
        {
            //disable enemy
            anim.SetBool("dead", true);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Enemy died");
            this.enabled= false;
            Gate.SetTrigger("Open");
        }
        
    }
}

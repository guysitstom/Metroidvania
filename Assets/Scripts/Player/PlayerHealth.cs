using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public string sceneName;
    public int maxHealth = 6;
    public int currentHealth;
    public GameObject Player;
    public bool Dead = false;

    public Animator anim;
    public Animator animator;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hurt");
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        animator.SetBool("inRange", false);
        Dead = true;
        //disable enemy
        anim.SetBool("death", true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        Invoke("DisableAnim", 1);
        Debug.Log("Enemy died");
        Player.tag = "Untagged";
        LayerMask.NameToLayer("Default");
        Invoke("DieScene", 2);
    }

    void DieScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    private void DisableAnim()
    {
        anim.enabled = false;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Healing"))
        {
            currentHealth = maxHealth;
        }
    }



}
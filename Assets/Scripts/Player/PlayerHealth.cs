using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public string sceneName;
    [Range(0,6)]
    public int maxHealth = 6;
    public static int currentHealth;
    public GameObject Player;
    public bool Dead = false;
    private static bool first =true;

    public Animator anim;
    
    public Animator[] animators;
    
    public GameObject[] Health;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if ((SceneManager.GetActiveScene().name ==("Level one") || SceneManager.GetActiveScene().name == ("Final Level")) && first)
        {
            currentHealth = maxHealth;
            first= false;
        }
        
        for (int i = 5; i >= currentHealth; i--)
        {
            Health[i].SetActive(false);
        }
    }
    public void TakeDamage(int damage)
    {
        Health[currentHealth - 1].SetActive(false);
        currentHealth -= damage;
        anim.SetTrigger("hurt");
        if (currentHealth <= 0)
        {
            
            Death();
        }
    }
    public void Death()
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetBool("inRange", false);
        } 
        
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
        first= true;
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
            for (int i = 0; i < maxHealth; i++)
            {
                Health[i].SetActive(true);
            }
        }
    }



}
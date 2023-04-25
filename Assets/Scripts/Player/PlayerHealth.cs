using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 6;
    public int currentHealth;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(DamageAnimation());

        if (currentHealth <= 0)
        {
            anim.SetBool("death", true);
            Invoke("Die", 2f);
        }
    }

    void Die()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }

}
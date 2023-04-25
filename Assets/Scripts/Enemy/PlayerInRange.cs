using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour
{
    [SerializeField] private GameObject alert;
    public AudioSource alertSound;

 
    public Transform EnemyMidPoint;
    public float SightRange = 0.5f;
    public LayerMask PlayerLayer;
    public Animator anim;
    private bool alerted= false;
    void Update()
    {
        Collider2D[] PlayerDetected = Physics2D.OverlapCircleAll(EnemyMidPoint.position, SightRange, PlayerLayer);
        foreach (Collider2D enemy in PlayerDetected)
        {
            if (!alerted)
            {
                alert.SetActive(true);
                alerted = true;
                GetComponent<Enemy_Flip>().LookAtPlayer();
                alertSound.Play();
                StartCoroutine( Wait());
                
            }
            
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(EnemyMidPoint.position, SightRange);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("inRange", true);
        alert.SetActive(false);
    }
}

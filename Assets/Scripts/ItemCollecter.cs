using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    public AudioSource colectsound;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Healing"))
        {
            Destroy(collision.gameObject);
            colectsound.Play();
        }
    }

}
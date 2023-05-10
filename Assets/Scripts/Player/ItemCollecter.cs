 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    public AudioSource colectsound;
    public bool HasDash = true;
    [SerializeField] public HasDash Dash;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Healing"))
        {
            Destroy(collision.gameObject);
            colectsound.Play();
            Debug.Log("Sound Played");
        }
        else if (collision.gameObject.CompareTag("DashUnlock"))
        {
            Destroy(collision.gameObject);
            Dash.hasDash = HasDash;
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] AudioSource alarm;
    [SerializeField] Animator explosion;
    [SerializeField] SpriteRenderer Blackground;

    public void WhiteOut()
    {
        alarm.Stop();
        explosion.SetTrigger("Start");
    }
    public void BlackGround()
    {
        Blackground.enabled = true;
    }
}

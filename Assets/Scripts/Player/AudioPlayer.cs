using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource attack;
    [SerializeField] AudioSource walk;
    void Start()
    {
   

    }

    public void Attack()
    {
        attack.Play();
    }
    public void Walk() 
    {
        walk.Play();    
    }
}

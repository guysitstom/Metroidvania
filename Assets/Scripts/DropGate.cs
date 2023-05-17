using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGate : MonoBehaviour
{

    [SerializeField] GameObject Gate;
    // Start is called before the first frame update
    void Start()
    {
        Gate.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Gate.SetActive(true);
        Destroy(this.gameObject);
    }
}

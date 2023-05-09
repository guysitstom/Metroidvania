using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
public class FallingObjects : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, 0.5f);
    }

    void SpawnObject()
    {
        float x = Random.Range(-10, 10);
        float z = Random.Range(5,6);
        Instantiate(target, new Vector3(x, z, 0), Quaternion.identity);
    }
}

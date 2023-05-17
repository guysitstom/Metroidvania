using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamright : MonoBehaviour
{
    [SerializeField] Transform cam;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x + speed, cam.position.y, transform.position.z);
    }
}

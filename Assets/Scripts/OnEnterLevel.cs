using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using UnityEngine;

public class OnEnterLevel : MonoBehaviour
{
    public GameObject entrance;
    public GameObject exit;
    public GameObject BossExit;
    GameObject tag;

    [SerializeField] public BossLevel bossLevel;
    [SerializeField] public SceneInfo sceneInfo;

    public Vector3 offsetEntrance = new Vector3(1f, 0.5f, 0);
    public Vector3 offsetExit = new Vector3(-1f, 0.5f, 0);
    private Rigidbody2D body;

    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {


        Vector3 offset = sceneInfo.isNextScene ? offsetEntrance : offsetExit;

        if (bossLevel.isBossScene  == true)
        {
           tag=BossExit;
            body.position = tag.transform.position + offset;
            
        }
        else
        {
            GameObject target = sceneInfo.isNextScene ? entrance : exit;

            body.position = target.transform.position + offset;
        }
       
    }


}
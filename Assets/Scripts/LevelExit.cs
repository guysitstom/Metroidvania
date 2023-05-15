using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelExit : MonoBehaviour
{
    public string sceneName;
    public bool isNextScene = true;
    public bool isBossScene = false;
    public GameObject Player;

    [SerializeField] public SceneInfo sceneInfo;
    [SerializeField] public BossLevel bossLevel;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player)
        {
            bossLevel.isBossScene = isBossScene;
            sceneInfo.isNextScene = isNextScene;
            SceneManager.LoadScene(sceneName);
        }

    }

}
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

    public GameObject Player;

    [SerializeField] public SceneInfo sceneInfo;
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player)
        {

            sceneInfo.isNextScene = isNextScene;
            SceneManager.LoadScene(sceneName);
        }

    }

}
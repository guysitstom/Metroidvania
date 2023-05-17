using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Changescene : MonoBehaviour
{
    
    void Endcard()
    {
        SceneManager.LoadScene("End Scene");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level one");
    }
}

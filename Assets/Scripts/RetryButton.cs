using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    [SerializeField] HasDash hasDash;
    
    public void Retry()
    {
        hasDash.hasDash = false;
        SceneManager.LoadScene("Level one");
    }
    public void RetryBoss()
    {
        SceneManager.LoadScene("Final Level");
    }
    public void Quit()
    {
        Application.Quit();
    }
}

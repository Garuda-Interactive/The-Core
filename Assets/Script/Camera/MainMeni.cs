using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeni : MonoBehaviour
{
    
    public void PlayTraningGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Exitgame()
    {
        Application.Quit();
    }
}

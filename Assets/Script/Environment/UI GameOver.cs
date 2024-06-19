using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    public void Retry()// ulang dari awal
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void LoadScene(string sceneName)//Pindah ke Scene Lain
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}

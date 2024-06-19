using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    public PLYRUltimate pausePlayerUlti;

    void Start()
    {
        pausePlayerUlti = FindObjectOfType<PLYRUltimate>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        if (pausePlayerUlti != null)
        {
            pausePlayerUlti.enabled = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        if (pausePlayerUlti != null)
        {
            pausePlayerUlti.enabled = true;
        }
    }

    public void Retry()// ulang dari awal
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void LoadScene(string sceneName)//Pindah ke Scene Lain
    {
        SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PROPFinish : MonoBehaviour
{
    public GameObject Finish;
    AUDIOManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnlockNewLevel();
            audioManager.PlaySFX(audioManager.Finish);
            Finish.SetActive(true);
            Time.timeScale = 0f;

            AUDIOBackgroundMusic.Instance.PauseMusic();
        }
    }

    void UnlockNewLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (currentLevel >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel );
            PlayerPrefs.Save();
            Debug.Log("Unlocked Level: " + (currentLevel ));
        }

    }
}

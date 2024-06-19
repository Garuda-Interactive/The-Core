using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AUDIOBackgroundMusic : MonoBehaviour
{
    public static AUDIOBackgroundMusic Instance;
    public AUDIOSound[] musicSound;
    public AudioSource[] musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeMusic();
    }

    public void PauseMusic()
    {
        musicSource[0].Stop();
    }

    public void ChangeMusic()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Changing music for scene: " + sceneIndex);

        if (sceneIndex < musicSound.Length)
        {
            musicSource[0].Stop();
            musicSource[0].clip = musicSound[sceneIndex].clip;
            musicSource[0].Play();
        }
        else
        {
            Debug.LogWarning("No music found for scene index: " + sceneIndex);
        }
    }

    public void PlayMusic(string name)
    {
        AUDIOSound s = System.Array.Find(musicSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Source Not Found");
        }
        else
        {
            musicSource[0].clip = s.clip;
            musicSource[0].Play();
        }
    }

    public void ToggleMusic()
    {
        musicSource[0].mute = !musicSource[0].mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource[0].volume = volume;
    }

    public bool IsMusicOn()
    {
        return !musicSource[0].mute;
    }
}

[System.Serializable]
public class AUDIOSound
{
    public string name;
    public AudioClip clip;
}

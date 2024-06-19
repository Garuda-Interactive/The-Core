using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AUDIOUICOntrol : MonoBehaviour
{
    public Image musicOnImage;
    public Image musicOffImage;

    private void Start()
    {
        UpdateMusicIcon();
    }

    public void ToggleMusic()
    {
        if (AUDIOBackgroundMusic.Instance != null)
        {
            AUDIOBackgroundMusic.Instance.ToggleMusic();
            UpdateMusicIcon();
        }
        else
        {
            Debug.LogError("AUDIOBackgroundMusic instance is not initialized.");
        }
    }

    private void UpdateMusicVolume(float value)
    {
        if (AUDIOBackgroundMusic.Instance != null)
        {
            AUDIOBackgroundMusic.Instance.MusicVolume(value);
        }
        else
        {
            Debug.LogError("AUDIOBackgroundMusic instance is not initialized.");
        }
    }

    private void UpdateMusicIcon()
    {
        if (AUDIOBackgroundMusic.Instance != null)
        {
            bool isMusicOn = AUDIOBackgroundMusic.Instance.IsMusicOn();
            musicOnImage.enabled = isMusicOn;
            musicOffImage.enabled = !isMusicOn;
        }
        else
        {
            Debug.LogError("AUDIOBackgroundMusic instance is not initialized.");
        }
    }
}

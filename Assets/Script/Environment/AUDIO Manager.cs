using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIOManager : MonoBehaviour
{
    [Header("------- Audio -------")]
    public AudioSource musixSource;
    public AudioSource SFXSource;

    [Header("------- SFX -------")]
    public AudioClip Sword;
    public AudioClip SwordUlti;
    public AudioClip Finish;
    public AudioClip GameOver;
    public AudioClip HealthItem;
    public AudioClip ShieldItem;
    public AudioClip PowerUpItem;
    public AudioClip UltiItem;
    public AudioClip Dogde;
    public AudioClip CakarMusuh;
    public AudioClip PukulanMusuh;
    public AudioClip TembakanMusuh;


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

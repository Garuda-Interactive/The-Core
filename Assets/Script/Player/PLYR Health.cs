using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLYRHealth : MonoBehaviour
{
    public int maxNyawa = 10;
    public int nyawaSekarang;
    public PLYRHealthBarUI HealthBarUI;
    public bool nyawaKebal = false;
    public GameObject AuraHealth;
    public GameObject GameOver;
    AUDIOManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        nyawaSekarang = maxNyawa;

        if (HealthBarUI != null)
        {
            HealthBarUI.SetMaxHealth(nyawaSekarang);
        }
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    public void KerusakanPlayer(int damage)
    {
        if (nyawaKebal)
        {
            Debug.Log("Player Kebal");
        }
        else
        {
            nyawaSekarang -= damage;
            if (HealthBarUI != null)
            {
                HealthBarUI.SetHealth(nyawaSekarang);
            }

            if (nyawaSekarang <= 0)
            {
                Die();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemHealth"))
        {
            audioManager.PlaySFX(audioManager.HealthItem);
            nyawaSekarang = Mathf.Clamp(nyawaSekarang + 5, 0, maxNyawa); // Clamp health
            other.gameObject.SetActive(false);

            if (HealthBarUI != null)
            {
                HealthBarUI.SetHealth(nyawaSekarang);
            }

            AuraHealth.SetActive(true);
            Invoke(nameof(ActiveAura), 1.5f);

        }
        if(other.CompareTag("Enemy Bullet") || other.CompareTag("Bos Bullet"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void ActiveAura()
    {
        AuraHealth.SetActive(false);
    }

    void Die()
    {
        audioManager.PlaySFX(audioManager.GameOver);
        Destroy(gameObject);
        Time.timeScale = 0f;
        GameOver.SetActive(true);

        AUDIOBackgroundMusic.Instance.PauseMusic();
    }
}

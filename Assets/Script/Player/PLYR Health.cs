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

    // Start is called before the first frame update
    void Start()
    {
        nyawaSekarang = maxNyawa;

        if (HealthBarUI != null)
        {
            HealthBarUI.SetMaxHealth(nyawaSekarang);
        }
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
            nyawaSekarang = Mathf.Clamp(nyawaSekarang + 1, 0, maxNyawa); // Clamp health
            other.gameObject.SetActive(false);

            if (HealthBarUI != null)
            {
                HealthBarUI.SetHealth(nyawaSekarang);
            }
        }
        if(other.CompareTag("Enemy Bullet") || other.CompareTag("Bos Bullet"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

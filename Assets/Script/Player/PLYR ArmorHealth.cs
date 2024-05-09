using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYRArmorHealth : MonoBehaviour
{
    public int maxNyawaArmor;
    public int nyawaArmorSekarang;
    public PLYRArmorHealthBarUI HealthBarUI;
    public PLYRHealth NyawaArmor;
    // Start is called before the first frame update
    void Start()
    {
        nyawaArmorSekarang = maxNyawaArmor;

        if (HealthBarUI != null)
        {
            HealthBarUI.SetMaxHealth(nyawaArmorSekarang);
        }
    }

    public void KerusakanArmor(int damage)
    {
        nyawaArmorSekarang -= damage;
        if (HealthBarUI != null)
        {
            HealthBarUI.SetHealth(nyawaArmorSekarang);
        }

        if (nyawaArmorSekarang <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        if (HealthBarUI != null)
        {
            HealthBarUI.gameObject.SetActive(false);
        }
        if(NyawaArmor != null)
        {
            NyawaArmor.nyawaKebal = false;
        }

    }
}

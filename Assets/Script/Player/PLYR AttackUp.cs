using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYRAttackUp : MonoBehaviour
{
    public MonoBehaviour script1;
    public MonoBehaviour script2;
    public float waktuAktifArmor;
    public GameObject Armor;
    public GameObject ArmorHealthBarUI;
    private PLYRHealth PlayerHealth;
    private void Start()
    {
        PlayerHealth = GetComponent<PLYRHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemDamage"))
        {
            Destroy(other.gameObject);
            script1.enabled = false;
            script2.enabled = true;
            Invoke(nameof(AttackUpOff), 10f);
        }

        if (other.CompareTag("ItemArmor"))
        {
            Destroy(other.gameObject);
            Armor.SetActive(true);
            ArmorHealthBarUI.SetActive(true);
            PlayerHealth.nyawaKebal = true;
            Invoke(nameof(ArmorOff), waktuAktifArmor);
        }
    }
    private void AttackUpOff()
    {
        script1.enabled = true;
        script2.enabled = false;
    }
    public void ArmorOff()
    {
        if (Armor != null && ArmorHealthBarUI != null)
        {
            Armor.SetActive(false);
            ArmorHealthBarUI.SetActive(false);
        }

        if (PlayerHealth != null)
        {
            PlayerHealth.nyawaKebal = false;
        }
    }
}

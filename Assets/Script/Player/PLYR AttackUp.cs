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
    public GameObject AuraAttackUP;
    private PLYRHealth PlayerHealth;
    AUDIOManager audioManager;

    private void Start()
    {
        PlayerHealth = GetComponent<PLYRHealth>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemDamage"))
        {
            audioManager.PlaySFX(audioManager.PowerUpItem);
            Destroy(other.gameObject);
            script1.enabled = false;
            script2.enabled = true;
            AuraAttackUP.SetActive(true);
            Invoke(nameof(AttackUpOff), 10f);
        }

        if (other.CompareTag("ItemArmor"))
        {
            audioManager.PlaySFX(audioManager.ShieldItem);
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
        AuraAttackUP.SetActive(false);
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

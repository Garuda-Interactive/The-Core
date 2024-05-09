using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ENMYHealth : MonoBehaviour
{
    public int maxNyawaMusuh ;
    public int nyawaMusuhSekarang;  
    public ENMYHealthBarUI healthBarUI;

    void Start()
    {
        nyawaMusuhSekarang = maxNyawaMusuh;
        if (healthBarUI != null)
        {
            healthBarUI.SetMaxHealth(maxNyawaMusuh);
        }
    }

    public void KerusakanEnemy(int damage)
    {
        nyawaMusuhSekarang -= damage;
        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(nyawaMusuhSekarang);
        }

        if (nyawaMusuhSekarang <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player Bullet"))
        {
            other.gameObject.SetActive(false);
        }    
    }
}
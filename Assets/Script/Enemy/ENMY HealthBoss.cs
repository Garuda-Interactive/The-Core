using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ENMYHealthBoss : MonoBehaviour
{
    public int maxNyawaMusuh;
    public int nyawaMusuhSekarang;
    public ENMYHealthBarUI healthBarUI;
    public GameObject Jembatan1;
    public float healthBarDisplayRange = 10f; // Jarak untuk menampilkan health bar
    private Transform player;
    public GameObject Tentakel1;
    public GameObject Tentakel2;

    void Start()
    {
        nyawaMusuhSekarang = maxNyawaMusuh;
        if (healthBarUI != null)
        {
            healthBarUI.SetMaxHealth(maxNyawaMusuh);
            healthBarUI.gameObject.SetActive(false); // Mulai dengan health bar yang tidak aktif
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Periksa jarak antara musuh dan pemain
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (healthBarUI != null)
            {
                healthBarUI.gameObject.SetActive(distanceToPlayer <= healthBarDisplayRange);
            }
        }
    }

    public void KerusakanBossEnemy(int damage)
    {
        nyawaMusuhSekarang -= damage;
        if (healthBarUI != null)
        {
            healthBarUI.SetHealth(nyawaMusuhSekarang);
        }

        if (nyawaMusuhSekarang <= 0)
        {
            healthBarUI.gameObject.SetActive(false);
            Tentakel1.SetActive(false);
            Tentakel2.SetActive(false);
            Destroy(gameObject);
            Jembatan1.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Bullet"))
        {
            other.gameObject.SetActive(false);
        }
    }
}

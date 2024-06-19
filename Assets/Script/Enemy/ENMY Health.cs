using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENMYHealth : MonoBehaviour
{
    public int maxNyawaMusuh;
    public int nyawaMusuhSekarang;
    public GameObject objectToSpawn;
    public ENMYHealthBarUI healthBarUI;

    private GameObject spawnedObject; // Referensi ke objek yang diinstansiasi

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
            Destroy(gameObject); // Hancurkan objek musuh
            StartCoroutine(Dead());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Bullet"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void Respawn()
    {
        spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

    private IEnumerator Dead()
    {
        Respawn();
        yield return new WaitForSeconds(0.5f);
        Destroy(spawnedObject); // Hancurkan objek yang diinstansiasi

    }
}

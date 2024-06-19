using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENMYBullet : MonoBehaviour
{
    public int damage;
    public GameObject explosionPrefab; // Prefab ledakan

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PLYRHealth nyawaPlayer = other.GetComponent<PLYRHealth>();
            if (nyawaPlayer != null)
            {
                nyawaPlayer.KerusakanPlayer(damage);
                StartCoroutine(HandleCollision());
            }
        }
        else if (other.CompareTag("Armor"))
        {
            PLYRArmorHealth nyawaArmor = other.GetComponent<PLYRArmorHealth>();
            if (nyawaArmor != null)
            {
                nyawaArmor.KerusakanArmor(damage);
                StartCoroutine(HandleCollision());
            }
        }
    }

    private IEnumerator HandleCollision()
    {
        TriggerExplosion(); // Menampilkan ledakan
        yield return new WaitForSeconds(1f); // Delay sebelum peluru dinonaktifkan
        gameObject.SetActive(false); // Menonaktifkan peluru
    }

    void TriggerExplosion()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}

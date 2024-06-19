using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYRBullet : MonoBehaviour
{
    public int damage = 5;
    public GameObject explosionPrefab; // Prefab ledakan

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf) // Cek apakah objek aktif
        {
            if (other.CompareTag("Enemy"))
            {
                ENMYHealth nyawaEnemy = other.GetComponent<ENMYHealth>();
                if (nyawaEnemy != null)
                {
                    nyawaEnemy.KerusakanEnemy(damage);
                    StartCoroutine(HandleCollision());
                }
            }
            else if (other.CompareTag("Boss"))
            {
                ENMYHealthBoss nyawaBoss = other.GetComponent<ENMYHealthBoss>();
                if (nyawaBoss != null)
                {
                    nyawaBoss.KerusakanBossEnemy(damage);
                    StartCoroutine(HandleCollision());
                }
            }
            else if (other.CompareTag("Property"))
            {
                PROPHealth nyawaProp = other.GetComponent<PROPHealth>();
                if (nyawaProp != null)
                {
                    nyawaProp.KerusakanProp(damage);
                    StartCoroutine(HandleCollision());
                }
            }
        }
    }


    private IEnumerator HandleCollision()
    {
        TriggerExplosion(); // Menampilkan ledakan
        yield return new WaitForSeconds(2f); // Delay sebelum peluru dinonaktifkan
        gameObject.SetActive(false); // Menonaktifkan peluru
    }

    void TriggerExplosion()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            StartCoroutine(DestroyExplosion(explosion));
        }
    }

    private IEnumerator DestroyExplosion(GameObject explosion)
    {
        yield return new WaitForSeconds(1f); // Menunggu 1 detik
        Destroy(explosion); // Menghancurkan objek ledakan
    }
}

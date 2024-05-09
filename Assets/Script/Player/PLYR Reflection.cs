using UnityEngine;
using System.Collections;

public class PLYRReflection : MonoBehaviour
{
    public GameObject bulletEnemy;
    public GameObject bulletBos;
    public Transform firePoint; // Tempat keluar peluru
    public float timeAttack;
    public GameObject shield;
    public float shieldDuration = 1f;
    private bool isShieldActive = false;
    private Transform enemy; // Menyimpan referensi ke musuh
    private Animator anim;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ActivateShield();
        }
    }

    private void ActivateShield()
    {
        if (!isShieldActive)
        {
            anim.SetTrigger("PLYR Parry");
            isShieldActive = true;
            shield.SetActive(true);
            Invoke(nameof(DeactivateShield), shieldDuration);
        }
    }

    private void DeactivateShield()
    {
        isShieldActive = false;
        shield.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isShieldActive && other.CompareTag("Enemy Bullet"))
        {
            bulletEnemy.SetActive(true);
            bulletBos.SetActive(false);
            Vector3 bulletDirection = other.transform.forward;
            ReflectBullet(bulletDirection);
        }
        if (isShieldActive && other.CompareTag("Bos Bullet"))
        {
            bulletEnemy.SetActive(false);
            bulletBos.SetActive(true);
            Vector3 bulletDirection = other.transform.forward;
            ReflectBullet(bulletDirection);
        }
    }

    private void ReflectBullet(Vector3 bulletDirection)
    {
        if (transform == null) return; // Memeriksa apakah transform masih valid

        // Menghitung vektor dari pemain ke musuh
        Vector3 directionToEnemy = (bulletDirection - transform.position).normalized;

        // Memantulkan peluru ke arah musuh
        Vector3 reflectedDirection = Vector3.Reflect(directionToEnemy, transform.forward);

        GameObject bulletPrefab = bulletEnemy.activeSelf ? bulletEnemy : bulletBos;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Instantiate peluru dari firePoint
        bullet.GetComponent<Rigidbody>().velocity = reflectedDirection * 10f; // Adjust speed as needed

        StartCoroutine(DestroyBullet(bullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timeAttack);
        Destroy(bullet);
    }
}
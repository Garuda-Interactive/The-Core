using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PLYRAttackPoint : MonoBehaviour
{
    public Transform firePoint; // Titik tembakan
    public GameObject bulletPrefab; // Prefab peluru
    public float timeAttack = 0.5f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("PLYR Attack");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.right;

            StartCoroutine(DestroyBullet(bullet)); // Memanggil coroutine untuk menghapus peluru setelah 0,2 detik
        }
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timeAttack);
        Destroy(bullet);
    }
}

using System.Collections;
using UnityEngine;

public class ENMYShoot : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float nextFireTime;
    public int timeAttack;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time + fireRate;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (player != null && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        if (player != null)
        {
            EnemyFlip();
        }
    }

    private void Shoot()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = direction * 10f; // Adjust speed as needed

        StartCoroutine(DestroyBullet(bullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timeAttack);
        Destroy(bullet);
    }

    void EnemyFlip()
    {
        if (player.position.x > transform.position.x) //Enemy ke arah kanan
        {
            spriteRenderer.flipX = true;
        }
        else // posisi awal
        {
            spriteRenderer.flipX = false;
        }
    }
}

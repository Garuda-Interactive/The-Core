using System.Collections;
using UnityEngine;

public class ENMYShootBoss : MonoBehaviour
{
    private Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint; // Titik keluarnya peluru
    public float fireRate = 1f;
    private float nextFireTime;
    public int timeAttack;
    private SpriteRenderer spriteRenderer;
    public float shootDistance = 10f;
    private Animator anim;
    public float initialDelay = 2f; // Delay awal sebelum mulai menembak

    public float shootingDuration = 10f; // Durasi menembak terus menerus
    public float nonShootingDuration = 20f; // Durasi tidak menembak
    AUDIOManager audioManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine(ShootingCycle());
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    private IEnumerator ShootingCycle()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // Menembak selama shootingDuration
            float shootingEndTime = Time.time + shootingDuration;
            while (Time.time < shootingEndTime)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);
                if (player != null && distanceToPlayer < shootDistance)
                {
                    anim.SetBool("Boss Shoot", true);
                    if (Time.time > nextFireTime)
                    {
                        audioManager.PlaySFX(audioManager.TembakanMusuh);
                        Shoot();
                        nextFireTime = Time.time + fireRate;
                    }
                    EnemyFlip();
                }

                yield return null; // Tunggu satu frame
            }

            // Tidak menembak selama nonShootingDuration
            anim.SetBool("Boss Shoot", false);
            yield return new WaitForSeconds(nonShootingDuration);
        }
    }

    private void Shoot()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Menggunakan posisi firePoint
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
        if (player.position.x > transform.position.x) // Enemy ke arah kanan
        {
            spriteRenderer.flipX = true;
        }
        else // posisi awal
        {
            spriteRenderer.flipX = false;
        }
    }
}

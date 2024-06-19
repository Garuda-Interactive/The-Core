using System.Collections;
using UnityEngine;

public class ENMYShootStraight : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float nextFireTime;
    public int timeAttack;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public float shootDistance = 10f; // Jarak untuk mulai menembak
    AUDIOManager audioManager;
   

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time + fireRate;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < shootDistance)
            {
                if (Time.time > nextFireTime)
                {
                    audioManager.PlaySFX(audioManager.TembakanMusuh);
                    Shoot();
                    nextFireTime = Time.time + fireRate;
                }
            }
            else
            {
                anim.SetBool("ENMY Shoot", false); // Set animasi menembak menjadi false
            }

            EnemyFlip();
        }
    }

    private void Shoot()
    {
        anim.SetBool("ENMY Shoot", true);

        Vector3 directionToPlayer = player.position - transform.position;
        Vector3 direction = Vector3.zero;

        if (directionToPlayer.x < 0) // Pemain berada di sebelah kiri
        {
            direction = Vector3.left;
        }
        else if (directionToPlayer.x > 0) // Pemain berada di sebelah kanan
        {
            direction = Vector3.right;
        }

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

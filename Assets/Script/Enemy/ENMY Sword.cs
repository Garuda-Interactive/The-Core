using System.Collections;
using UnityEngine;

public class ENMYSword : MonoBehaviour
{
    public Transform player;
    public GameObject swordPrefab; // Prefab objek pedang
    public float attackRate; // Waktu antara setiap serangan
    private float nextAttackTime;
    public float attackDuration = 0.1f; // Durasi serangan pedang
    public float attackRange = 5f; // Jarak minimum untuk menyerang
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private EnemyMovement enemyMovement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextAttackTime = Time.time + attackRate;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (player != null && Time.time > nextAttackTime)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackRange)
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
            }
            else
            {
                enemyMovement.enabled = true;
            }
        }
        if(player != null)
        {
            EnemyFlip();
        }
    }

    private void Attack()
    {
        anim.SetBool("ENMY Attack",true);

        // Buat objek pedang dan arahkan ke arah player
        GameObject sword = Instantiate(swordPrefab, transform.position, Quaternion.identity);
        sword.transform.LookAt(player);

        enemyMovement.enabled = false;

        // Set durasi serangan
        StartCoroutine(DestroySword(sword));
    }


    IEnumerator DestroySword(GameObject sword)
    {
        // Hancurkan pedang setelah durasi serangan
        yield return new WaitForSeconds(attackDuration);
        Destroy(sword);

        anim.SetBool("ENMY Attack",false);
        enemyMovement.enabled = true;
    }

    void EnemyFlip()
    {
        if(player.position.x > transform.position.x) //Enemy ke arah kanan
        {
            spriteRenderer.flipX = true;
        }
        else // posisi awal
        {
            spriteRenderer.flipX = false;
        }
    }
}

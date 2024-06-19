// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Animations;

// public class PLYRAttackPoint : MonoBehaviour
// {
//     public Transform firePoint; // Titik tembakan
//     public GameObject bulletPrefab; // Prefab peluru
//     public float timeAttack = 0.5f;
//     private Animator anim;
//     private PLYRMovement moving;
//     AUDIOManager audioManager;


//     void Start()
//     {
//         anim = GetComponent<Animator>();
//         moving = GetComponent<PLYRMovement>();
//         audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
//     }

//     void Update()
//     {
//         Shoot();
//     }

//     void Shoot()
//     {
//         if (Input.GetKeyDown(KeyCode.Space) && !moving.isMoving)
//         {
//             audioManager.PlaySFX(audioManager.Sword);
//             anim.SetTrigger("PLYR Attack");
//             GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//             Rigidbody rb = bullet.GetComponent<Rigidbody>();
//             rb.velocity = firePoint.right;

//             StartCoroutine(DestroyBullet(bullet)); // Memanggil coroutine untuk menghapus peluru setelah 0,2 detik
//         }
//     }

//     IEnumerator DestroyBullet(GameObject bullet)
//     {
//         yield return new WaitForSeconds(timeAttack);
//         Destroy(bullet);
//     }
// }

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
    private PLYRMovement moving;
    private AUDIOManager audioManager;
    private int attackCount = 0; // Menyimpan jumlah serangan

    void Start()
    {
        anim = GetComponent<Animator>();
        moving = GetComponent<PLYRMovement>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !moving.isMoving)
        {
            attackCount++;

            if (attackCount % 3 == 0)
            {
                audioManager.PlaySFX(audioManager.Sword);
                anim.SetTrigger("PLYR AttackV2");
            }
            else
            {
                audioManager.PlaySFX(audioManager.Sword);
                anim.SetTrigger("PLYR Attack");
            }

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.right;

            StartCoroutine(DestroyBullet(bullet)); // Memanggil coroutine untuk menghapus peluru setelah 0,5 detik
        }
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timeAttack);
        Destroy(bullet);
    }
}

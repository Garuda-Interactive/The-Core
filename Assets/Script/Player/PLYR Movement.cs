using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYRMovement : MonoBehaviour
{
    public float speed;
    public float speedTambahan;
    private float speedAsli;
    [HideInInspector] public float sumbuXAxis;
    [HideInInspector] public float sumbuZAxis;
    private SpriteRenderer spriteRenderer;
    public bool hadapkiri = false;
    private Animator anim;
    private bool isDodging;
    private float lastMoveTime;
    private float dodgeCooldown = 0.2f;

    public Transform DodgePoint; // Titik tembakan
    public GameObject EffectDodge; // Prefab peluru
    public bool isMoving;
    AUDIOManager audioManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    void Update()
    {
        sumbuXAxis = Input.GetAxis("Horizontal");
        sumbuZAxis = Input.GetAxis("Vertical");

        Movement();
        Dodge();
        Facing();
    }

    void Movement()
    {
        Vector3 direction = new Vector3(sumbuXAxis, 0, sumbuZAxis);
        transform.Translate(direction * Time.deltaTime * speedAsli);

        if (direction != Vector3.zero)
        {
            anim.SetBool("PLYR Walk", true);
            lastMoveTime = Time.time;
            isMoving = true;
        }
        else
        {
            anim.SetBool("PLYR Walk", false);
            isMoving = false;
        }
    }

    void Dodge()
    {
        if (!isDodging && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            if (Time.time - lastMoveTime < dodgeCooldown && PlayerIsMoving())
            {
                audioManager.PlaySFX(audioManager.Dogde);
                isDodging = true;
                speedAsli = speed * speedTambahan;
                Shoot();
            }
        }

        if (isDodging)
        {

            anim.SetBool("PLYR Dodge", true);
            speedAsli = speed * speedTambahan;

            // Batasan pergerakan sumbu z
            Vector3 newPosition = transform.position;
            newPosition.z = Mathf.Clamp(newPosition.z, -3.6f, 0.8f);
            transform.position = newPosition;

            // Dodge selesai setelah beberapa detik
            StartCoroutine(EndDodge());
        }
        else
        {
            speedAsli = speed;
        }
    }

    bool PlayerIsMoving()
    {
        // Periksa apakah pemain sedang bergerak dengan memeriksa nilai sumbu x dan z
        return Mathf.Abs(sumbuXAxis) > 0.1f || Mathf.Abs(sumbuZAxis) > 0.1f;
    }

    void Shoot()
    {
        if (EffectDodge != null && DodgePoint != null)
        {
            GameObject bullet = Instantiate(EffectDodge, DodgePoint.position, DodgePoint.rotation);

            if (hadapkiri)
            {
                bullet.transform.right = -transform.right;
            }
            else
            {
                bullet.transform.right = transform.right;
            }

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = bullet.transform.right * 10f; // Sesuaikan dengan kecepatan yang diinginkan
            StartCoroutine(DestroyBullet(bullet));
        }
        else
        {
            Debug.LogError("EffectDodge atau DodgePoint tidak diatur. Pastikan semua referensi diperlukan telah ditetapkan.");
        }
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(bullet);
    }

    IEnumerator EndDodge()
    {
        yield return new WaitForSeconds(0.5f); // Durasi dodge
        isDodging = false;
        speedAsli = speed;
        anim.SetBool("PLYR Dodge", false);
    }

    void Facing()
    {
        if (sumbuXAxis < 0)
        {
            spriteRenderer.flipX = true;
            hadapkiri = true;
        }
        if (sumbuXAxis > 0)
        {
            spriteRenderer.flipX = false;
            hadapkiri = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYRMovement : MonoBehaviour
{
    public float speed;
    public float speedTambahan;
    private float speedAsli;
    private float sumbuXAxis;
    private float sumbuZAxis;
    private SpriteRenderer spriteRenderer;
    public bool hadapkiri = false;
    private Animator anim;
    private bool isDodging;
    private float lastMoveTime;
    private float dodgeCooldown = 0.2f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        }
        else
        {
            anim.SetBool("PLYR Walk", false);
        }
    }

    void Dodge()
    {
        if (!isDodging && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            if (Time.time - lastMoveTime < dodgeCooldown)
            {
                isDodging = true;
                speedAsli = speed * speedTambahan;
            }
        }

        if (isDodging)
        {
            speedAsli = speed * speedTambahan;

            // Dodge selesai setelah beberapa detik
            StartCoroutine(EndDodge());
        }
        else
        {
            speedAsli = speed;
        }
    }

    IEnumerator EndDodge()
    {
        yield return new WaitForSeconds(0.2f); // Durasi dodge
        isDodging = false;
        speedAsli = speed;
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

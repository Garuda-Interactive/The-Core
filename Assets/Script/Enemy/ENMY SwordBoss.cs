using System.Collections;
using UnityEngine;

public class ENMYSwordBoss : MonoBehaviour
{
    private Transform player;
    public GameObject sword; // Objek pedang yang diaktifkan/dinonaktifkan
    public float attackRange = 10f; // Jarak minimum untuk mulai menyerang
    public float attackTriggerRange = 5f; // Jarak minimum untuk serangan
    public int timeAttack;
    public float initialDelay = 2f; // Delay awal sebelum mulai menyerang

    public float attackingDuration = 10f; // Durasi menyerang terus menerus
    public float nonAttackingDuration = 20f; // Durasi tidak menyerang
    private Animator anim;
    AUDIOManager audioManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        StartCoroutine(AttackCycle());
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    private IEnumerator AttackCycle()
    {
        while (true)
        {
            // Periksa jarak antara musuh dan pemain
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                // Tidak menyerang selama nonAttackingDuration
                anim.SetBool("ENMY Tentakel Attack", false); // Matikan animasi serangan saat tidak menyerang
                sword.SetActive(false); // Matikan objek pedang saat tidak menyerang
                yield return new WaitForSeconds(nonAttackingDuration);

                // Menyerang selama attackingDuration
                anim.SetBool("ENMY Tentakel Attack", true);
                yield return StartCoroutine(ActivateDeactivateSword(attackingDuration));
            }
            else
            {
                // Tunggu satu frame sebelum memeriksa jarak lagi
                yield return null;
            }
        }
    }

    private IEnumerator ActivateDeactivateSword(float duration)
    {
        float endTime = Time.time + duration;
        while (Time.time < endTime)
        {
            if (Vector3.Distance(transform.position, player.position) <= attackTriggerRange)
            {
                audioManager.PlaySFX(audioManager.PukulanMusuh);
                sword.SetActive(true); // Aktifkan objek pedang saat menyerang
                yield return new WaitForSeconds(timeAttack);
                sword.SetActive(false); // Nonaktifkan objek pedang setelah waktu serangan habis
                yield return new WaitForSeconds(timeAttack);
            }
            else
            {
                // Jika pemain keluar dari jarak serangan, matikan pedang dan tunggu
                sword.SetActive(false);
                yield return null;
            }
        }
    }
}

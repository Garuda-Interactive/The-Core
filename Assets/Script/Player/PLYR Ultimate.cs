using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PLYRUltimate : MonoBehaviour
{
    public Transform firePoint; // Titik tembakan
    public GameObject peluruPrefab; // Prefab peluru
    public float timeAttack = 2f;
    private Animator anim;

    public int JumlahPointUltimate = 0;
    public int MaxPointUltimate;
    public PLYRUltimatePointBarUI UltimatePointBarUI;
    private PLYRMovement arahPlayer;
    AUDIOManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        arahPlayer = GetComponent<PLYRMovement>();
        if (UltimatePointBarUI != null)
        {
            UltimatePointBarUI.SetMaxPointUltimate(MaxPointUltimate); // Mengatur nilai maksimum dari bar Ultimate
            UltimatePointBarUI.SetPointUltimate(JumlahPointUltimate); // Mengatur nilai awal dari bar Ultimate
        }
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0f )return; //jangan melakukan apa apa ketika pause 
        Ultimate();
    }

    void Ultimate()
    {
        if (JumlahPointUltimate < MaxPointUltimate)
        {
            JumlahPointUltimate = Mathf.Min(JumlahPointUltimate + 1, MaxPointUltimate);
            if (UltimatePointBarUI != null)
            {
                UltimatePointBarUI.SetPointUltimate(JumlahPointUltimate); // Mengatur nilai bar Ultimate secara perlahan sesuai dengan jumlah poin Ultimate
            }
        }

        if (JumlahPointUltimate >= MaxPointUltimate && Input.GetKeyDown(KeyCode.F))
        {
            audioManager.PlaySFX(audioManager.SwordUlti);
            Shoot();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item Ultimate"))
        {
            audioManager.PlaySFX(audioManager.UltiItem);
            JumlahPointUltimate = Mathf.Clamp(JumlahPointUltimate + 2000 ,0,MaxPointUltimate);
            other.gameObject.SetActive(false);

            {
                UltimatePointBarUI.SetPointUltimate(JumlahPointUltimate); // Mengatur nilai bar Ultimate secara perlahan sesuai dengan jumlah poin Ultimate
            }
        }
    }

    void Shoot()
    {
        anim.SetTrigger("PLYR Attack");

        GameObject bullet = Instantiate(peluruPrefab, firePoint.position, firePoint.rotation);

        if (arahPlayer.hadapkiri)
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

        JumlahPointUltimate = 0;
        if (UltimatePointBarUI != null)
        {
            UltimatePointBarUI.SetPointUltimate(JumlahPointUltimate); // Mengatur nilai bar Ultimate kembali ke 0 setelah menggunakan ultimate
        }
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timeAttack);
        Destroy(bullet);
    }

}
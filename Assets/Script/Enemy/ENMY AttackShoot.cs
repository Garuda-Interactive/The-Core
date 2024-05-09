using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENMYAttackShoot : MonoBehaviour
{
    public Transform titikTembakEnemy;
    public GameObject peluruEnemy;
    public float delayTembakan;
    public float kecepatanPeluru;
    // Start is called before the first frame update
    private void Start()
    {
        // memulai tembak secara otomatis
        InvokeRepeating("Shoot", 1f, delayTembakan);
    }

    private void Shoot()
    {
        // men-spawn peluru pada titik tembak musuh
        GameObject newBullet = Instantiate(peluruEnemy, titikTembakEnemy.position, Quaternion.identity);

        // memberi kecepatan pada peluru ke arah kiri
        newBullet.GetComponent<Rigidbody>().velocity = -transform.right * kecepatanPeluru;
    }
}

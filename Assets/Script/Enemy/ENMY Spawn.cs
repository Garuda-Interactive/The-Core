using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENMYSpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // prefab musuh
    public float spawnRate = 2f; // waktu spawn setiap musuh
    public float spawnRadiusY = 5f; // jarak spawn musuh pada sumbu Y
    public float spawnX = 0.1f; // jarak spawn musuh pada sumbu X
    public float spawnZ = 1f; // jarak spawn musuh pada sumbu Z
    public int maxEnemies = 10; // jumlah maksimum musuh pada waktu yang sama
    public float delayBeforeSpawn = 10f; // jeda waktu sebelum mulai men-spawn musuh
    private int currentEnemies = 0;
    private Transform player;
    public float activePortal = 10f; // jarak untuk mengaktifkan portal

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // mulai spawn musuh setelah delay
        Invoke("StartSpawning", delayBeforeSpawn);
    }

    private void StartSpawning()
    {
        // mulai memanggil SpawnEnemy secara berulang dengan interval spawnRate
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer >= activePortal && IsInvoking("SpawnEnemy"))
        {
            CancelInvoke("SpawnEnemy");
        }
        else if (distanceToPlayer < activePortal && !IsInvoking("SpawnEnemy"))
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnRate);
        }
    }

    private void SpawnEnemy()
    {
        // jika jumlah musuh melebihi batas, maka tidak akan di-spawn lagi
        if (currentEnemies >= maxEnemies)
        {
            return;
        }

        // menghitung posisi spawn secara acak di dalam radius yang telah ditentukan
        Vector3 spawnPosition = new Vector3(spawnX, Random.Range(-spawnRadiusY, spawnRadiusY), spawnZ);

        // men-spawn musuh pada posisi yang telah dihitung
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position + spawnPosition, Quaternion.identity);

        // menambah jumlah musuh yang aktif
        currentEnemies++;
    }
}

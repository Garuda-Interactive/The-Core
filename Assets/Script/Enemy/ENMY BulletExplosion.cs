using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENMYBulletExplosion : MonoBehaviour
{
    public float delayLifeExplosion = 1.0f;

    void Explosion()
    {
        // Memulai coroutine yang akan menghilangkan objek setelah waktu yang ditentukan
        StartCoroutine(HideExplosion());
    }

    IEnumerator HideExplosion()
    {
        // Menunggu selama disappearTime detik
        yield return new WaitForSeconds(delayLifeExplosion);

        // Menghilangkan objek dengan menonaktifkan game object ini
        Destroy(gameObject);
    }
}

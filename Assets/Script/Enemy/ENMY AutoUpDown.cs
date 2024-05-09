using UnityEngine;

public class EnemyAutoUpDown : MonoBehaviour
{
    public float speed = 1f; // Kecepatan pergerakan objek
    public float height = 1f; // Ketinggian maksimum yang ingin dicapai
    private Vector3 startPosition; // Posisi awal objek

    private void Start()
    {
        startPosition = transform.position; // Menyimpan posisi awal objek
    }

    private void Update()
    {
        // Menghitung pergerakan objek naik dan turun secara berulang
        float newZ = startPosition.z + Mathf.Sin(Time.time * speed) * height;

        // Mengubah posisi objek secara vertikal
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}

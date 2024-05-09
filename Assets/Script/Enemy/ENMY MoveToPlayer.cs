using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Transform player
    public float moveSpeed = 3f; // Kecepatan gerakan enemy
    public float stoppingDistance = 8f; // Jarak di mana musuh akan berhenti
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Memeriksa apakah player sudah ada
        if (player != null)
        {
            // Menghitung jarak antara musuh dan player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Jika jarak kurang dari 8, gerakkan ke player
            if (distanceToPlayer < stoppingDistance)
            {
                anim.SetBool("ENMY Walk",true);

                // Menghitung arah ke player
                Vector3 targetDirection = player.position - transform.position;
                targetDirection.y = 0; // Mengabaikan pergerakan ke atas/bawah
                targetDirection.Normalize();

                // Gerakkan ke arah player
                transform.position += targetDirection * moveSpeed * Time.deltaTime;
            }
            else
            {
                anim.SetBool("ENMY Walk",false);
            }
        }
    }
}

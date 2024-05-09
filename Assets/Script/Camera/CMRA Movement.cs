using UnityEngine;

public class CMRAMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 0.125f;
    public float BatasanSumbuX = 1f; // Batasan jarak kamera dari player pada sumbu x

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            float PlayerX = playerTransform.position.x;
            float SumbuX = transform.position.x;
            float newX = Mathf.Clamp(PlayerX, SumbuX - BatasanSumbuX, SumbuX + BatasanSumbuX);
            newX = Mathf.Max(newX, 0); // Membatasi nilai newX tidak kurang dari 0

            Vector3 targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}



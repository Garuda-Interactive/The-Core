using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYRUltimateBullet : MonoBehaviour
{
    public int kecepatanPeluru;
    
    void Update()
    {
        transform.Translate(Vector3.right * kecepatanPeluru * Time.deltaTime);
    }
}
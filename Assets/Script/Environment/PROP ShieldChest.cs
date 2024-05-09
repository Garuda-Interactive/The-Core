using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROPShieldChese : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    private BoxCollider trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        AllEnemyDead();
    }
    void AllEnemyDead()
    {
        if ((Enemy1 == null || !Enemy1.activeSelf) &&
            (Enemy2 == null || !Enemy2.activeSelf) &&
            (Enemy3 == null || !Enemy3.activeSelf) &&
            (Enemy4 == null || !Enemy4.activeSelf) &&
            (Enemy5 == null || !Enemy5.activeSelf))
        {
            Debug.Log("Semua musuh sudah mati!");
            trigger.enabled = false;
        }
    }

}

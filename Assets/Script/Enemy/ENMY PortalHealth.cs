using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENMYPortalHealth : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Finish;
    AUDIOManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AUDIOManager>();
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
            (Enemy4 == null || !Enemy4.activeSelf))
        {
            audioManager.PlaySFX(audioManager.Finish);
            Finish.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Semua Pilar hancur!");
            Destroy(gameObject);
        }
    }
}

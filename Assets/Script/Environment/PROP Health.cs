using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROPHealth : MonoBehaviour
{
    public int maxNyawaProp = 1;
    public int nyawaSekarangProp;
    public GameObject objectToSpawn;
    public float respawnTime = 0.5f;
    void Start()
    {
        nyawaSekarangProp = maxNyawaProp;
    }

    public void KerusakanProp(int damage)
    {
        nyawaSekarangProp -= damage;
        if (nyawaSekarangProp <= 0)
        {
            Destroy(gameObject);
            Respawn();
        }
    }

    private void Respawn()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}

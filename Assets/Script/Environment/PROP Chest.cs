using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROPChest : MonoBehaviour
{
    public int maxNyawaProp = 1;
    public int nyawaSekarangProp;
    public GameObject objectToSpawn;
    public float delayOpenChest;
    private Animator anim;

    void Start()
    {
        nyawaSekarangProp = maxNyawaProp;
        anim = GetComponent<Animator>();
    }

    public void KerusakanProp(int damage)
    {
        nyawaSekarangProp -= damage;
        if (nyawaSekarangProp <= 0)
        {
            anim.SetTrigger("PROP Chest");
            StartCoroutine(OpenChest());
        }
    }

    private void Respawn()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

    private IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(delayOpenChest);
        Destroy(gameObject);
        Respawn();
    }
}

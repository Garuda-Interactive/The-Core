using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROPHealth : MonoBehaviour
{
    public int maxNyawaProp = 1;
    public int nyawaSekarangProp;

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
        }
    }

}

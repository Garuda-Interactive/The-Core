using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLYRDamage : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ENMYHealth nyawaEnemy = other.GetComponent<ENMYHealth>();
            if (nyawaEnemy != null)
            {
                nyawaEnemy.KerusakanEnemy(damage);
            }
        }

        if (other.CompareTag("Property"))
        {
            PROPHealth nyawaProp = other.GetComponent<PROPHealth>();
            if (nyawaProp != null)
            {
                nyawaProp.KerusakanProp(damage);
            }
        }
    }
}

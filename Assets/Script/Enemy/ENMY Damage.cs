using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENMYDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PLYRHealth nyawaPlayer = other.GetComponent<PLYRHealth>();
            if (nyawaPlayer != null)
            {
                nyawaPlayer.KerusakanPlayer(damage);
            }
        }
        if(other.CompareTag("Armor"))
        {
            PLYRArmorHealth nyawaArmor = other.GetComponent<PLYRArmorHealth>();
            if(nyawaArmor != null){
                nyawaArmor.KerusakanArmor(damage);
            }
        }
        
    }
}

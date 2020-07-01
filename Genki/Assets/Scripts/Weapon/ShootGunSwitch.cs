using System.Collections;
using System.Collections.Generic;
using Genki.Character;
using UnityEngine;

public class ShootGunSwitch : MonoBehaviour
{
    public GameObject weapon;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<WeaponSystem>().EquipWeapon(this.weapon);
        }
    }
}

using System;
using Genki.Control;
using UnityEngine;

namespace Genki.Weapon
{
    public class WeaponConfig : MonoBehaviour
    {
        public float maxAttackRange = 2f;
        public float weaponDamage = 10f;
        public float timeToWaitBetweenHits = 2.5f;
        public float bulletForce = 20f;

        public virtual void GenerateBullet(Transform firePoint, IUnitControl owner)
        {
            throw new NotImplementedException("Please Use derived WeaponConfig");
        }
    }
}

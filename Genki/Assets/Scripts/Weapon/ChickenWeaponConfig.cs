using Genki.Control;
using UnityEngine;

namespace Genki.Weapon
{
    public class ChickenWeaponConfig: WeaponConfig
    {
        public override void GenerateBullet(Transform firePoint, IUnitControl owner)
        {
            var direction = -firePoint.up * bulletForce;
            GenerateBullet(owner, firePoint.position, firePoint.rotation, direction);
        }
    }
}

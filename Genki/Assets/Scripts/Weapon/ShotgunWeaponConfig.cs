using Genki.Control;
using UnityEngine;

namespace Genki.Weapon
{
    public class ShotgunWeaponConfig: WeaponConfig
    {
        public override void GenerateBullet(Transform firePoint, IUnitControl owner)
        {
            var up = firePoint.up;
            var right = firePoint.right;
            var rotation = firePoint.rotation;
            var position = firePoint.position;

            var direction1 = -up * bulletForce + right*2f;
            var direction2 = -up * bulletForce;
            var direction3 = -up * bulletForce - right*2f;

            GenerateBullet(owner, position, rotation, direction1);
            GenerateBullet(owner, position, rotation, direction2);
            GenerateBullet(owner, position, rotation, direction3);
        }
    }
}

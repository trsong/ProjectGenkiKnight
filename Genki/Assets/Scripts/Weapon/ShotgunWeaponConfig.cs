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

            GenerateOneBullet(owner, position, rotation, direction1);
            GenerateOneBullet(owner, position, rotation, direction2);
            GenerateOneBullet(owner, position, rotation, direction3);
        }
        
        public override void GenerateBullet(IUnitControl owner, Vector2 position, Quaternion rotation, Vector2 direction)
        {
            var right = Vector2.Perpendicular(direction);
            var direction1 = direction + right*2f;
            var direction2 = direction * bulletForce;
            var direction3 = direction * bulletForce - right*2f;
            
            GenerateOneBullet(owner, position, rotation, direction1);
            GenerateOneBullet(owner, position, rotation, direction2);
            GenerateOneBullet(owner, position, rotation, direction3);
        }
    }
}

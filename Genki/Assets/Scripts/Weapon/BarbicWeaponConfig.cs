using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Genki.Control;

namespace Genki.Weapon
{
    public class BarbicWeaponConfig : WeaponConfig
    {
        public override void GenerateBullet(IUnitControl owner, Vector2 position, Quaternion rotation, Vector2 direction)
        {
            var right = Vector2.Perpendicular(direction);
            var direction1 = direction * bulletForce;

            GenerateOneBullet(owner, position, rotation, direction1);
        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Genki.Control;

namespace Genki.Weapon
{
    public class BossWeaponConfig : WeaponConfig
    {
        public float speed = 10f;

        public override bool canBreakTrough()
        {
            return true;
        }


        public override void GenerateBullet(Transform pos, IUnitControl owner)
        {
            var up = pos.up;
            var right = pos.right;
            var rotation = pos.rotation;
            var position = pos.position;

            var direction1 = up * bulletForce + right * 2f;
            var direction2 = up * bulletForce;
            var direction3 = up * bulletForce - right * 2f;
            var direction4 = -up * bulletForce + right * 2f;
            var direction5 = -up * bulletForce - right * 2f;
            var direction6 = -up * bulletForce;
            var direction7 = -right * bulletForce;
            var direction8 = right * bulletForce;

            var offset = direction2.normalized;
            var r_offset = Vector3.right;
            GenerateBullet(owner, position + offset, rotation, direction1);
            GenerateBullet(owner, position + offset, rotation, direction2);
            GenerateBullet(owner, position + offset, rotation, direction3);
            GenerateBullet(owner, position - offset, rotation, direction4);
            GenerateBullet(owner, position - offset, rotation, direction5);
            GenerateBullet(owner, position - offset, rotation, direction6);
            GenerateBullet(owner, position - r_offset, rotation, direction7);
            GenerateBullet(owner, position + r_offset, rotation, direction8);


        }
    }
}
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Genki.Control;
using Genki.Utility;

namespace Genki.Weapon
{
    public class BossRotationWeaponConfig : WeaponConfig
    {
        public float shotSpinRate = 5f; // shot angle change amount after each round of shooting
        public float bulletAngle = 10f; // 10 degree
        public int numBullet = 8;

        private bool isClockWise = true;
        private int counter = 0;
        private float shotAngle = 0f;
        private float sectorAngle
        {
            get => 360f / numBullet;
        }

        public override bool canBreakTrough()
        {
            return true;
        }

        public override void GenerateBullet(Transform pos, IUnitControl owner)
        {
            Vector2 baseDirection = pos.up;
            Vector2 basePos = pos.position;
            Vector2 baseFirePos = basePos + baseDirection;

            if (isClockWise)
            {
                for (int i = 0; i < numBullet; i++)
                {
                    var firePos = UtilityFunction.Rotate(baseFirePos, basePos, -(i * sectorAngle + shotAngle));
                    var relativeFireDirection = firePos - basePos;
                    var firePosPlus = firePos + relativeFireDirection;
                    var bulletPos = UtilityFunction.Rotate(firePosPlus, firePos, -bulletAngle);
                    var bulletDirection = (bulletPos - firePos) * bulletForce;
                    GenerateBullet(owner, firePos, Quaternion.identity, bulletDirection);
                    counter++;
                }
                if(counter % 24 == 0)
                {
                    isClockWise = false;
                }
            }
            else
            {
                for (int i = 0; i < numBullet; i++)
                {
                    var firePos = UtilityFunction.Rotate(baseFirePos, basePos, i * sectorAngle + shotAngle);
                    var relativeFireDirection = firePos - basePos;
                    var firePosPlus = firePos + relativeFireDirection;
                    var bulletPos = UtilityFunction.Rotate(firePosPlus, firePos, bulletAngle);
                    var bulletDirection = (bulletPos - firePos) * bulletForce;
                    GenerateBullet(owner, firePos, Quaternion.identity, bulletDirection);
                    counter++;
                }
                if (counter % 24 == 0)
                {
                    isClockWise = true;
                }
            } 

            shotAngle += shotSpinRate;
        }
    }
}
    
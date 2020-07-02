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
        
        public virtual void GenerateBullet(IUnitControl owner, Vector2 position, Quaternion rotation, Vector2 direction)
        {
            GameObject b = Instantiate(gameObject, position, rotation);
            BulletCollision bc = b.GetComponent<BulletCollision>();
            bc.owner = owner;
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.AddForce(direction, ForceMode2D.Impulse);
        }
    }
}

using System;
using Genki.Abilitiy;
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
        public Ability weaponAbility = null;

        public virtual void GenerateBullet(Transform firePoint, IUnitControl owner)
        {
            throw new NotImplementedException("Please Use derived WeaponConfig");
        }
        
        public virtual void GenerateBullet(IUnitControl owner, Vector2 position, Quaternion rotation, Vector2 direction)
        {
            GenerateOneBullet(owner, position, rotation, direction);
        }
        
        protected virtual void GenerateOneBullet(IUnitControl owner, Vector2 position, Quaternion rotation, Vector2 direction)
        {
            GameObject b = Instantiate(gameObject, position, rotation);
            BulletCollision bc = b.GetComponent<BulletCollision>();
            bc.setOwner(owner);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.AddForce(direction, ForceMode2D.Impulse);
        }

        public virtual bool canBreakTrough()
        {
            return false;
        }
    }
}

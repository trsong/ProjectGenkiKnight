using Genki.Control;
using UnityEngine;

namespace Genki.Weapon
{
    public class MagicWeaponConfig: WeaponConfig
    {
        public float speed = 10f;
        
        public override void GenerateBullet(IUnitControl owner, Vector2 position, Quaternion rotation, Vector2 direction)
        {
            GameObject b = Instantiate(gameObject, position, rotation);
            BulletCollision bc = b.GetComponent<BulletCollision>();
            bc.owner = owner;
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * speed;
        }
    }
}

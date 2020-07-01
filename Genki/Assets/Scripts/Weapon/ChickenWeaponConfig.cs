using Genki.Control;
using UnityEngine;

namespace Genki.Weapon
{
    public class ChickenWeaponConfig: WeaponConfig
    {
        public override void GenerateBullet(Transform firePoint, IUnitControl owner)
        {
            GameObject b = Instantiate(gameObject, firePoint.position, firePoint.rotation);
            BulletCollision bc = b.GetComponent<BulletCollision>();
            bc.owner = owner;
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}

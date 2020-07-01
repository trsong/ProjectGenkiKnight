using Genki.Control;
using UnityEngine;

namespace Genki.Weapon
{
    public class ShotgunWeaponConfig: WeaponConfig
    {
        public override void GenerateBullet(Transform firePoint, IUnitControl owner)
        {
            GameObject a = Instantiate(gameObject, firePoint.position, firePoint.rotation);
            GameObject b = Instantiate(gameObject, firePoint.position, firePoint.rotation);
            GameObject c = Instantiate(gameObject, firePoint.position, firePoint.rotation);
            BulletCollision abc = a.GetComponent<BulletCollision>();
            abc.owner = owner;
            Rigidbody2D arb = a.GetComponent<Rigidbody2D>();
            arb.AddForce(-firePoint.up * bulletForce + firePoint.right*2f, ForceMode2D.Impulse);

            BulletCollision bbc = b.GetComponent<BulletCollision>();
            bbc.owner = owner;
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            brb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);

            BulletCollision cbc = c.GetComponent<BulletCollision>();
            cbc.owner = owner;
            Rigidbody2D crb = c.GetComponent<Rigidbody2D>();
            crb.AddForce(-firePoint.up * bulletForce - firePoint.right*2f, ForceMode2D.Impulse);
        }
    }
}

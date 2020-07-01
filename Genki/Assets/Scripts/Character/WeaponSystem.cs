using Genki.Control;
using Genki.Weapon;
using UnityEngine;

namespace Genki.Character
{
    public class WeaponSystem: MonoBehaviour
    {
        public GameObject weapon;
        
        public float baseDamage = 10f;
        public float criticalHitChance = 0.1f;
        public float criticalHitMultiplier = 2f;
        public float meleeDamage = 0f;

        private IUnitControl owner = null;
        private WeaponConfig currentWeaponConfig;
        
        // Use this for initialization
        void Start()
        {
            owner = GetComponent<BaseUnitControl>();
            currentWeaponConfig = weapon.GetComponent<WeaponConfig>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void EquipWeapon(GameObject updateWeapon)
        {
            weapon = updateWeapon;
            currentWeaponConfig = updateWeapon.GetComponent<WeaponConfig>();
        }

        public float CalculateDamage()
        {
            bool isCriticalHit = UnityEngine.Random.Range(0f, 1f) <= criticalHitChance;
            float damageBeforeCritical = baseDamage + currentWeaponConfig.weaponDamage;
            if (isCriticalHit)
            {
                return damageBeforeCritical * criticalHitMultiplier;
            }
            else
            {
                return damageBeforeCritical;
            }
        }

        public void shoot(Transform firePoint)
        {
            if(currentWeaponConfig.weaponType == "Shotgun"){
                GameObject a = Instantiate(weapon.gameObject, firePoint.position, firePoint.rotation);
                GameObject b = Instantiate(weapon.gameObject, firePoint.position, firePoint.rotation);
                GameObject c = Instantiate(weapon.gameObject, firePoint.position, firePoint.rotation);
                BulletCollision abc = a.GetComponent<BulletCollision>();
                abc.owner = owner;
                Rigidbody2D arb = a.GetComponent<Rigidbody2D>();
                arb.AddForce(-firePoint.up * currentWeaponConfig.bulletForce + firePoint.right*2f, ForceMode2D.Impulse);

                BulletCollision bbc = b.GetComponent<BulletCollision>();
                bbc.owner = owner;
                Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
                brb.AddForce(-firePoint.up * currentWeaponConfig.bulletForce, ForceMode2D.Impulse);

                BulletCollision cbc = c.GetComponent<BulletCollision>();
                cbc.owner = owner;
                Rigidbody2D crb = c.GetComponent<Rigidbody2D>();
                crb.AddForce(-firePoint.up * currentWeaponConfig.bulletForce - firePoint.right*2f, ForceMode2D.Impulse);
            
            }

            if(currentWeaponConfig.weaponType== "Chicken"){
                GameObject b = Instantiate(weapon.gameObject, firePoint.position, firePoint.rotation);
                BulletCollision bc = b.GetComponent<BulletCollision>();
                bc.owner = owner;
                Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
                rb.AddForce(-firePoint.up * currentWeaponConfig.bulletForce, ForceMode2D.Impulse);
            }
        }
    }
}

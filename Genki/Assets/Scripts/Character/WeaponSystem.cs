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
            if (weapon.gameObject)
            {
                GameObject b = Instantiate(weapon.gameObject, firePoint.position, firePoint.rotation);
                BulletCollision bc = b.GetComponent<BulletCollision>();
                bc.owner = owner;
                Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
                rb.AddForce(-firePoint.up * currentWeaponConfig.bulletForce, ForceMode2D.Impulse);
            }
        }
    }
}

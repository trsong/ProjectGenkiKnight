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
            currentWeaponConfig.GenerateBullet(firePoint, owner);
        }

        public void shootTarget(Transform target)
        {
            Vector2 direction = target.position - transform.position;
            Vector2 offset = direction.normalized;  // Avoid bullet bumps into shooter
            Transform me = gameObject.transform;
            Vector2 position = me.position;
            currentWeaponConfig.GenerateBullet(owner,  position + offset, Quaternion.identity, direction);
        }
    }
}

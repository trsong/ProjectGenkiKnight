using UnityEngine;

namespace Genki.Character
{
    public class WeaponSystem: MonoBehaviour
    {
        public WeaponConfig currentWeaponConfig;
        
        public float baseDamage = 10f;
        public float criticalHitChance = 0.1f;
        public float criticalHitMultiplier = 2f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void EquipWeapon(WeaponConfig weapon)
        {
            currentWeaponConfig = weapon;
        }

        public void AttackTarget(GameObject target)
        {
            target.GetComponent<HealthSystem>().TakeDamage(CalculateDamage());
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
    }
}

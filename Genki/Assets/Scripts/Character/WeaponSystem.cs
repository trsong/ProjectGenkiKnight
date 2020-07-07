using Genki.Control;
using Genki.Weapon;
using UnityEngine;

namespace Genki.Character
{
    public class WeaponSystem: MonoBehaviour
    {
        public GameObject weapon;
        public GameObject damagePopup = null;
        
        public float baseDamage = 10f;
        public float criticalHitChance = 0.1f;
        public float criticalHitMultiplier = 2f;
        public float meleeDamage = 0f;

        private IUnitControl owner = null;
        private WeaponConfig currentWeaponConfig;
        private DamagePopupControl damagePopupControl = null;

        private bool readyToAttack = true;
        private int timer = 0;

        private int MaxTimer => (int)(currentWeaponConfig.timeToWaitBetweenHits * 60);

        // Use this for initialization
        void Start()
        {
            owner = GetComponent<BaseUnitControl>();
            currentWeaponConfig = weapon.GetComponent<WeaponConfig>();
            if (damagePopup != null)
            {
                damagePopupControl = damagePopup.GetComponent<DamagePopupControl>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            timer++;
            if (timer > MaxTimer)
            {
                readyToAttack = true;
                timer = 0;
            }
        }

        public void EquipWeapon(GameObject updateWeapon)
        {
            weapon = updateWeapon;
            currentWeaponConfig = updateWeapon.GetComponent<WeaponConfig>();
        }

        public float CalculateDamage(IUnitControl target)
        {
            if (!target.getCharacterSystem().canAttack)
            {
                return 0f;
            }

            bool isCriticalHit = UnityEngine.Random.Range(0f, 1f) <= criticalHitChance;
            float damageBeforeCritical = baseDamage + currentWeaponConfig.weaponDamage;
            float dmg = isCriticalHit ? damageBeforeCritical * criticalHitMultiplier : damageBeforeCritical;
            if (damagePopupControl != null)
            {
                damagePopupControl.ShowDamage(target.getStartPosition(), (int) dmg, isCriticalHit);
            }
            return dmg;
        }

        public void shoot(Transform firePoint)
        {
            if (readyToAttack)
            {
                currentWeaponConfig.GenerateBullet(firePoint, owner);
                readyToAttack = false;
            }
        }

        public void shootTarget(Transform target)
        {
            if (readyToAttack)
            {
                Vector2 direction = target.position - transform.position;
                Vector2 offset = direction.normalized; // Avoid bullet bumps into shooter
                Transform me = gameObject.transform;
                Vector2 position = me.position;
                currentWeaponConfig.GenerateBullet(owner,  position + offset, Quaternion.identity, direction);

                readyToAttack = false;
            }
        }

        public void shootBoss(Transform pos)
        {
            if (readyToAttack)
            {
                currentWeaponConfig.GenerateBullet(pos, owner);
                readyToAttack = false;
            }
        }
    }
}

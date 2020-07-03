using Genki.Abilitiy;
using Genki.Character;
using Genki.Weapon;
using UnityEngine;

namespace Genki.Control
{
    public class BaseUnitControl : MonoBehaviour, IUnitControl
    {
        protected AbilitySystem abilitySystem;
        protected CharacterSystem characterSystem;
        protected WeaponSystem weaponSystem;
        protected HealthSystem healthSystem;
        
        protected virtual void Start()
        {
            weaponSystem = GetComponent<WeaponSystem>();
            characterSystem = GetComponent<CharacterSystem>();
            abilitySystem = GetComponent<AbilitySystem>();
            healthSystem = GetComponent<HealthSystem>();
        }

        protected void OnCollisionEnter2D(Collision2D other)
        {
            if (!characterSystem.canAttack) return;
            var isOtherEnemy = other.transform.CompareTag("Enemy");
            var isOtherPlayer = other.transform.CompareTag("Player");
            if (!isOtherEnemy && !isOtherPlayer) return;
            
            var isMeEnemy = characterSystem.isEnemy();
            if(isMeEnemy != isOtherEnemy){
                var enemyWeapon = other.gameObject.GetComponent<WeaponSystem>();
                healthSystem.TakeDamage(enemyWeapon.meleeDamage);
            }
        }
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Bullet"))
            {
                IUnitControl shooter = other.gameObject.GetComponent<BulletCollision>().getOwner();
                var enemyWeapon = shooter.getWeaponSystem();
                var damage = enemyWeapon.CalculateDamage();
                healthSystem.TakeDamage(damage);
            }
        }
        
        public CharacterSystem getCharacterSystem()
        {
            return characterSystem;
        }

        public WeaponSystem getWeaponSystem()
        {
            return weaponSystem;
        }

        public Vector2 getStartPosition()
        {
            return transform.position;
        }
    }
}

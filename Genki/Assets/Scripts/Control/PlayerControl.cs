using System;
using Genki.Abilitiy;
using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class PlayerControl : MonoBehaviour, IUnitControl
    {
        AbilitySystem abilitySystem;
        CharacterSystem characterSystem;
        WeaponSystem weaponSystem;
        HealthSystem healthSystem;
        
        void Start()
        {
            weaponSystem = GetComponent<WeaponSystem>();
            characterSystem = GetComponent<CharacterSystem>();
            abilitySystem = GetComponent<AbilitySystem>();
            healthSystem = GetComponent<HealthSystem>();
        }

        void Update()
        {
            if (characterSystem)
            {
                float xMove = Input.GetAxis("Horizontal");
                float yMove = Input.GetAxis("Vertical");
                characterSystem.moveCharacter(xMove, yMove);
            }
        }

        void BindKeyForAbility()
        {
            abilitySystem.bindKeyToAbility();
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.transform.tag == "Enemy"){
                healthSystem.TakeDamage(10);
            }

            if (other.transform.tag == "Bullet")
            {
                IUnitControl shooter = other.gameObject.GetComponent<BulletCollision>().owner;
                var shooterChar = shooter.getCharacterSystem();
                if (shooterChar.isEnemy())
                {
                    var enemyWeapon = shooter.getWeaponSystem();
                    enemyWeapon.AttackTarget(gameObject);
                }
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
    }
}
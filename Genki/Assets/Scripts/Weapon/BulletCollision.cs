using System;
using Genki.Abilitiy;
using Genki.Control;
using UnityEngine;
using Genki.Character;

namespace Genki.Weapon
{
    public class BulletCollision : MonoBehaviour
    {
        private Vector2 startPosition = Vector2.zero;
        private float maxDistance = 0f;
        private IUnitControl owner = null;
        private bool canBreakTrough = false;
        private Ability weaponAbility = null;

        public void setOwner(IUnitControl newOwner)
        {
            owner = newOwner;
            var weapon = newOwner.getWeaponSystem().weapon;
            var weaponConfig = weapon.GetComponent<WeaponConfig>();
            maxDistance = weaponConfig.maxAttackRange;
            startPosition = newOwner.getStartPosition();
            canBreakTrough = weaponConfig.canBreakTrough();
            weaponAbility = weaponConfig.weaponAbility;
        }

        public IUnitControl getOwner()
        {
            return owner;
        }

        void Update()
        {
            if (startPosition != Vector2.zero &&
                Vector2.Distance(startPosition, gameObject.transform.position) > maxDistance)
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 2);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (canBreakTrough)
            {
                return;
            }

            if (other.tag != "Bullet" && other.tag != "searcher")
            {
                var isMeEnemy = owner.getCharacterSystem().isEnemy();
                var otherCharacterSystem = other.gameObject.GetComponent<CharacterSystem>();
                var isOtherEnemy = otherCharacterSystem && otherCharacterSystem.isEnemy();
                if (isOtherEnemy && isMeEnemy) return;

                AbilitySystem abilitySystem = other.gameObject.GetComponent<AbilitySystem>();
                if (abilitySystem && weaponAbility)
                {
                    var abilityInstance = Instantiate(weaponAbility);
                    abilitySystem.addExternalEffect(abilityInstance);
                }

                Destroy(gameObject);
            }
        }
    }
}
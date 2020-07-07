using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New AttackAbilityData", menuName = "Attack Ability")]
    public class AttackAbility: Ability
    {
        public float changeAmount = 10f;
        private GameObject statusInstance = null;
        
        public override bool canApply(GameObject target)
        {
            if (!canStartTimer()) return false;
            return owner && !statusInstance;
        }

        protected override void activate(GameObject target)
        {
            if (owner != null)
            {
                var weaponSystem = owner.GetComponent<WeaponSystem>();
                weaponSystem.baseDamage += changeAmount;
                if (changeAmount > 0)
                {
                    statusInstance = attachBuff(icon);
                }
                else
                {
                    statusInstance = attachDebuff(icon);
                }
            }
        }

        protected override void deactivate()
        {
            if (owner)
            {
                var weaponSystem = owner.GetComponent<WeaponSystem>();
                weaponSystem.baseDamage -= changeAmount;
                Destroy(statusInstance);
                statusInstance = null;
            }
        }
    }
}

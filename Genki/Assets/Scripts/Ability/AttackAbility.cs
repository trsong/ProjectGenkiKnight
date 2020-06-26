using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    public class AttackAbility: Ability
    {
        public override bool canApply(GameObject target)
        {
            var targetChar = target.GetComponent<CharacterSystem>();
            return targetChar.isEnemy() && targetChar.canAttack;
        }

        public override void apply(GameObject target)
        {
            if (owner != null)
            {
                var weaponSystem = owner.GetComponent<WeaponSystem>();
                // weaponSystem.AttackTarget(target);
            }
        }
    }
}

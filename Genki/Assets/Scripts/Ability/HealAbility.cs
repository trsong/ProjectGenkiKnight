using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    public class HealAbility: Ability
    {
        public override bool canApply(GameObject target)
        {
            var targetChar = target.GetComponent<CharacterSystem>();
            return targetChar.enemyType == EnemyType.Player;
        }

        public override void apply(GameObject target)
        {
            if (owner != null)
            {
                var healthSystem = owner.GetComponent<HealthSystem>();
                var healAmount = 10f;
                healthSystem.Heal(healAmount);
            }
        }
    }
}

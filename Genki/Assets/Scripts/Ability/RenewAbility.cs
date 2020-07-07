using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New RenewAbilityData", menuName = "Renew Ability")]
    public class RenewAbility: Ability
    {
        protected override void activate(GameObject target)
        {
            var abilitySystem = owner.transform.GetComponent<AbilitySystem>();
            foreach (var ability in abilitySystem.abilities)
            {
                if (ability is RenewAbility) continue;
                ability.renew();
            }
        }
    }
}

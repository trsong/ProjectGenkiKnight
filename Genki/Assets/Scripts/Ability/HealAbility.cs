using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New HealAbilityData", menuName = "Heal Ability")]
    public class HealAbility: Ability
    {
        public float healAmount = 50f; 
        
        public override bool canApply()
        {
            if (!canStartTimer()) return false;
            
            if (owner)
            {
                var healthSystem = owner.GetComponent<HealthSystem>();
                return healthSystem.CanHeal();
            }
            return false;
        }

        protected override void activate()
        {
            if (owner)
            {
                var healthSystem = owner.GetComponent<HealthSystem>();
                healthSystem.Heal(healAmount);
            }
        }
    }
}

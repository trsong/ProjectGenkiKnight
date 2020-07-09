using System.Collections;
using System.Collections.Generic;
using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New ReviveAbilityData", menuName = "Revive Ability")]
    public class ReviveAbility: Ability
    {
        public float healAmount = 50f; 
        private GameObject statusInstance = null;
        
        public override bool canApply()
        {
            if (!canStartTimer()) return false;
            
            if (owner)
            {
                var healthSystem = owner.GetComponent<HealthSystem>();
                return healthSystem.IsDead();
            }
            return false;
        }

        protected override void activate()
        {
            if (owner)
            {
                
                var spriteRenderer = owner.GetComponent<SpriteRenderer>();
                var color = spriteRenderer.color;
                color.a = 0.5f;
                spriteRenderer.color = color;
                var characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.canAttack = false;
                
                var healthSystem = owner.GetComponent<HealthSystem>();
                healthSystem.Heal(healAmount);
                statusInstance = attachBuff(icon);
            }
        }

        protected override void deactivate()
        {
            if (owner)
            {
                var spriteRenderer = owner.GetComponent<SpriteRenderer>();
                var color = spriteRenderer.color;
                color.a = 1f;
                spriteRenderer.color = color;
                var characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.canAttack = true;
                
                Destroy(statusInstance);
                statusInstance = null;
            }
        }
    }
}

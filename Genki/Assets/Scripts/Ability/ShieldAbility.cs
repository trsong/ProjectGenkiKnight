using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New ShieldAbilityData", menuName = "Shield Ability")]
    public class ShieldAbility: Ability
    {
        public GameObject shieldCirclePrefab;

        private GameObject shieldInstance = null;
        
        public override bool canApply(GameObject target)
        {
            if (!canStartTimer()) return false;
            
            if (owner != null && shieldInstance == null)
            {
                var characterSystem = owner.GetComponent<CharacterSystem>();
                return characterSystem.canAttack;
            }
            return false;
        }

        protected override void activate(GameObject target)
        {
            if (owner != null)
            {
                var characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.canAttack = false;
                shieldInstance = Instantiate(shieldCirclePrefab, owner.transform);
            }
        }

        protected override void deactivate()
        {
            if (owner != null)
            {
                var characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.canAttack = true;
                Destroy(shieldInstance);
                shieldInstance = null;
            }
        }
    }
}

using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New ShieldAbilityData", menuName = "Shield Ability")]
    public class ShieldAbility: Ability
    {
        public GameObject shieldCirclePrefab;

        private GameObject shieldInstance = null;
        private GameObject statusInstance = null;

        private CharacterSystem characterSystem = null;
        
        public override bool canApply()
        {
            if (!canStartTimer()) return false;
            
            if (owner && !shieldInstance)
            {
                if(!characterSystem) characterSystem = owner.GetComponent<CharacterSystem>();
                return characterSystem.canAttack;
            }
            return false;
        }

        protected override void activate()
        {
            if (owner)
            {
                if(!characterSystem) characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.canAttack = false;
                shieldInstance = Instantiate(shieldCirclePrefab, owner.transform);
                statusInstance = attachBuff(icon);
            }
        }

        protected override void deactivate()
        {
            if (owner)
            {
                if(!characterSystem) characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.canAttack = true;
                Destroy(shieldInstance);
                shieldInstance = null;
                Destroy(statusInstance);
                statusInstance = null;
            }
        }
    }
}

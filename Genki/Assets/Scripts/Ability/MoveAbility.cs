using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New MoveAbilityData", menuName = "Move Ability")]
    public class MoveAbility: Ability
    {
        public float changeAmount = 2.5f;
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
                var characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.speed += changeAmount;
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
            if (!owner)
            {
                var characterSystem = owner.GetComponent<CharacterSystem>();
                characterSystem.speed -= changeAmount;
                Destroy(statusInstance);
                statusInstance = null;
            }
        }
    }
}

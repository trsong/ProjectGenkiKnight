using UnityEngine;

namespace Genki.Abilitiy
{
    public class AbilitySystem : MonoBehaviour
    {
        public Ability[] abilities;
        

        public void bindKeyToAbility()
        {
            
        }

        public void applyAbility(int abilityIndex, GameObject target = null)
        {
            bool canApplyAbility = abilities[abilityIndex].canApply(target);
            if (canApplyAbility)
            {
                
            }
        }
    }
}

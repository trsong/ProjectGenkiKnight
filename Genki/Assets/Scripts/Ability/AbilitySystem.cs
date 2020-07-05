using System;
using UnityEngine;

namespace Genki.Abilitiy
{
    public class AbilitySystem : MonoBehaviour
    {
        public Ability[] abilities;

        void Start()
        {
            if (abilities == null) return;
            foreach (var ability in abilities)
            {
                ability.setOwner(gameObject);
            }
        }

        public void bindKeyToAbility()
        {
            if (abilities == null) return;
            
            var abilityBar = GameObject.Find("AbilityBar");

            foreach (var ability in abilities)
            {
                ability.attachToAbilityBar(abilityBar);
            }
        }

        public void applyAbility(int abilityIndex, GameObject target = null)
        {
            if (abilities == null || abilityIndex >= abilities.Length)
            {
                return;
            }
            
            abilities[abilityIndex].apply(target);
        }

        void Update()
        {
            if (abilities == null) return;

            foreach (var ability in abilities)
            {
                ability.tick();
            }
        }
    }
}

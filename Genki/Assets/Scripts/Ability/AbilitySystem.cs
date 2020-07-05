using System;
using System.Collections.Generic;
using UnityEngine;

namespace Genki.Abilitiy
{
    public class AbilitySystem : MonoBehaviour
    {
        public List<Ability> abilities;
        private GameObject _abilityBar = null;

        private const int abilityBarCapacity = 8;

        public GameObject abilityBar
        {
            get
            {
                if(_abilityBar == null) _abilityBar = GameObject.Find("AbilityBar");
                return _abilityBar;
            }
        }

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

            foreach (var ability in abilities)
            {
                ability.attachToAbilityBar(abilityBar);
            }
        }

        public void attachAbilityToBar(Ability ability)
        {
            // if (abilities.Count >= abilityBarCapacity)
            // {
            //     var removedAbility = abilities[0];
            //     removedAbility.delete();
            //     abilities.RemoveAt(0);
            // }

            abilities.Add(ability);
            ability.setOwner(gameObject);
            ability.attachToAbilityBar(abilityBar);
        }

        public void applyAbility(int abilityIndex, GameObject target = null)
        {
            if (abilities == null || abilityIndex >= abilities.Count)
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

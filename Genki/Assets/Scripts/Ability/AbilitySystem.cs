using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Genki.Abilitiy
{
    public class AbilitySystem : MonoBehaviour
    {
        public List<Ability> abilities;
        private GameObject _abilityBar = null;

        private const int abilityBarCapacity = 8;
        private List<Ability> externalEffects;
        private int timer = 0;

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
            externalEffects = new List<Ability>();
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
            if (abilities.Count >= abilityBarCapacity)
            {
                var removedAbility = abilities[0];
                removedAbility.delete();
                abilities.RemoveAt(0);
            }

            ability.setOwner(gameObject);

            var existingAbility = abilities.Find(x => x.description == ability.description);
            if (existingAbility)
            {
                existingAbility.mergeAbility(ability);
            }
            else
            {
                abilities.Add(ability);
                ability.attachToAbilityBar(abilityBar);
            }
        }

        public void applyAbility(int abilityIndex, GameObject target = null)
        {
            if (abilities == null || abilityIndex >= abilities.Count)
            {
                return;
            }
            
            abilities[abilityIndex].setOwner(target);
            abilities[abilityIndex].apply();
        }

        void Update()
        {
            timer += 1;
            if (abilities == null) return;

            foreach (var ability in abilities)
            {
                ability.tick();
            }
            foreach (var ability in externalEffects)
            {
                ability.tick();
            }

            if (timer % 60 == 0)
            {
                List<Ability> updatedExternalEffects = new List<Ability>();
                foreach (var ability in externalEffects)
                {
                    if (ability.canApply())
                    {
                        ability.delete();
                        Destroy(ability);
                    }
                    else
                    {
                        updatedExternalEffects.Add(ability);
                    }
                }

                if (updatedExternalEffects.Count > 0)
                {
                    externalEffects = updatedExternalEffects;
                }
            }
        }

        public void addExternalEffect(Ability effect)
        {
            effect.setOwner(gameObject);
            effect.apply();
            externalEffects.Add(effect);
        }

        public bool attemptToRevive()
        {
            var reviveAbility = abilities.Find(x => x is ReviveAbility && x.canApply());
            if (reviveAbility)
            {
                reviveAbility.apply();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

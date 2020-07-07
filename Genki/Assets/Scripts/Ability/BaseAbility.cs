using System;
using UnityEngine;

namespace Genki.Abilitiy
{
    public abstract class Ability: ScriptableObject
    {
        public string description;
        public Sprite icon;
        public int maxQuantity = 99;
        public GameObject uiIconPrefab = null;
        public float maxCooldownInSec = 1f; // in seconds
        
        protected GameObject owner = null;
        
        private float cooldown;
        private bool canActivate = true;
        private int quantity = 0;
        private static int sharedCooldown = 0; // 3 secs common cd

        public void setOwner(GameObject newOwner)
        {
            owner = newOwner;
            quantity = maxQuantity;
            canActivate = true;
            cooldown = 0;
        }
        
        public void attachToAbilityBar(GameObject abilityBar)
        {
            if (!uiIconPrefab) return;
            var uiIconInstance = Instantiate(uiIconPrefab, abilityBar.transform);
            var uiIconControl = uiIconInstance.GetComponent<AbilityIconControl>();
            uiIconControl.setAbility(this);
        }


        public virtual bool canApply(GameObject target)
        {
            return canStartTimer();
        }

        public virtual void apply(GameObject target)
        {
            if (canApply(target))
            {
                startTimer();
                activate(target);
            }
        }

        protected abstract void activate(GameObject target);

        protected bool canStartTimer()
        {
            return canActivate && quantity > 0;
        }

        protected void startTimer()
        {
            if (canStartTimer())
            {
               canActivate = false;
               cooldown = maxCooldownInSec * 60;
               sharedCooldown = 3 * 60;
               quantity -= 1;
            }
        }

        public void tick()
        {
            if (sharedCooldown > 0)
            {
                sharedCooldown -= 1;
            }

            if (canStartTimer()) return;

            if (cooldown > 0)
            {
                cooldown -= 1;
            }
            else
            {
                canActivate = true;
            }
        }

        public int getCooldownInSec()
        {
            return (int) (cooldown + sharedCooldown) / 60;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public void delete()
        {
            quantity = 0;
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Genki.Abilitiy
{
    public abstract class Ability: ScriptableObject
    {
        public string description;
        public Sprite icon;
        public int maxQuantity = 99;
        public GameObject uiIconPrefab = null;
        public float maxCooldownInSec = 1f; // in seconds
        public float maxEffectTimeInSec = 0f; // in seconds
        public GameObject uiBuffPrefab = null;
        public GameObject uiDebuffPrefab = null;

        protected GameObject owner = null;

        private float effectTimeInSec = 0f;
        protected bool inEffect = false;
        private float cooldown;
        private bool canActivate = true;
        private int quantity = 0;
        private static int sharedCooldown = 0; // 3 secs common cd
        
        private GameObject _statusBar = null;
        protected GameObject statusBar
        {
            get
            {
                // Only player can access status bar
                if (!owner || !owner.transform.CompareTag("Player")) return null;
                if(_statusBar == null) _statusBar = GameObject.Find("StatusBar");
                return _statusBar;
            }
        }

        protected GameObject attachBuff(Sprite icon)
        {
            if (!owner || !owner.transform.CompareTag("Player")) return null;
            if (!statusBar || !uiBuffPrefab) return null;
            var statusInstance = Instantiate(uiBuffPrefab, statusBar.transform);
            statusInstance.transform.Find("Icon").GetComponent<Image>().sprite = icon;
            return statusInstance;
        }

        protected GameObject attachDebuff(Sprite icon)
        {
            if (!owner || !owner.transform.CompareTag("Player")) return null;
            if (!statusBar || !uiDebuffPrefab) return null;
            var statusInstance = Instantiate(uiDebuffPrefab, statusBar.transform);
            statusInstance.transform.Find("Icon").GetComponent<Image>().sprite = icon;
            return statusInstance;
        }

        public void setOwner(GameObject newOwner)
        {
            owner = newOwner;
            quantity = maxQuantity;
            canActivate = true;
            cooldown = 0;
            effectTimeInSec = maxEffectTimeInSec;
            inEffect = false;
        }
        
        public void attachToAbilityBar(GameObject abilityBar)
        {
            if (!uiIconPrefab) return;
            var uiIconInstance = Instantiate(uiIconPrefab, abilityBar.transform);
            var uiIconControl = uiIconInstance.GetComponent<AbilityIconControl>();
            uiIconControl.setAbility(this);
        }


        public virtual bool canApply()
        {
            return canStartTimer();
        }

        public virtual void apply()
        {
            if (canApply())
            {
                activate();
                startTimer();
                inEffect = true;
                effectTimeInSec = Math.Min(maxEffectTimeInSec, maxCooldownInSec) - 0.01f;
            }
        }

        protected abstract void activate();

        protected virtual void deactivate()
        {
        }

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

        public virtual void tick()
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

            if (inEffect && (maxCooldownInSec - cooldown/60) >= effectTimeInSec)
            {
                inEffect = false;
                deactivate();
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

        public void renew()
        {
            cooldown = 0;
            sharedCooldown = 0;
        }

        public void mergeAbility(Ability ability)
        {
            if (ability.owner != owner) return;
            if (ability.GetType() != GetType()) return;
            quantity += ability.quantity;
            ability.delete();
            renew();
        }
    }
}

using Genki.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New PoisonAbilityData", menuName = "Poison Ability")]
    public class PoisonAbility: Ability
    {
        public float poisonDmgInSec = 1f;
        private GameObject statusInstance = null;
        private HealthSystem healthSystem = null;
        public override bool canApply()
        {
            if (!canStartTimer()) return false;
            if (!healthSystem) healthSystem = owner.GetComponent<HealthSystem>();
            return owner && !statusInstance;
        }

        protected override void activate()
        {
            if (owner)
            {
                
                if (owner.transform.CompareTag("Player"))
                {
                    GameObject healthBar = GameObject.FindWithTag("PlayerHealthBar");
                    healthBar.transform.Find("Fill").GetComponent<Image>().color = Color.green;
                }
                healthSystem.canSelfRegen = false;
                statusInstance = attachDebuff(icon);
            }
        }

        protected override void deactivate()
        {
            if (owner)
            {
                healthSystem.canSelfRegen = true;
                if (owner.transform.CompareTag("Player"))
                {
                    GameObject healthBar = GameObject.FindWithTag("PlayerHealthBar");
                    healthBar.transform.Find("Fill").GetComponent<Image>().color = Color.red;
                }
                Destroy(statusInstance);
                statusInstance = null;
            }
        }

        public override void tick()
        {
            if (inEffect && healthSystem.healthAsPercentage > 0.01f)
            {
                healthSystem.TakeDamage(poisonDmgInSec / 60f);
            }
            base.tick();
        }
    }
}

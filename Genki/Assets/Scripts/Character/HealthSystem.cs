using System.Collections;
using System.Collections.Generic;
using Genki.Control;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Genki.Character
{
    public class HealthSystem : MonoBehaviour
    {
        
        public float maxHealthPoint = 100f;
        public float currentHealthPoint = 100f;
        public bool canSelfRegen = false;
        public HealthBarControl healthBar = null;

        public float healthAsPercentage
        {
            get => currentHealthPoint / maxHealthPoint;
        }
        
        void Update()
        {
            UpdateHealthBar();
            HealthRegen(); // Health Regen if canSelfRegen is True.
        }

        void UpdateHealthBar()
        {
            if (healthBar)
            {
                healthBar.setHealth(healthAsPercentage);
            }
        }

        void HealthRegen()
        {
            if(canSelfRegen && currentHealthPoint<maxHealthPoint)
            {
                if(currentHealthPoint <= 0)
                {
                    return;
                }
                Heal(0.05f);
            }

        }

        public void TakeDamage(float damage)
        {
            bool characterDies = (currentHealthPoint - damage <= 0);
            currentHealthPoint = Mathf.Clamp(currentHealthPoint - damage, 0f, maxHealthPoint);
            if (characterDies)
            {
                // Determine if character can revive or prompt death msg and restart the game
                KillCharacter();
            }
        }

        public void Heal(float healAmount)
        {
            currentHealthPoint = Mathf.Clamp(currentHealthPoint + healAmount, 0f, maxHealthPoint);
        }

        public bool CanHeal()
        {
            return (maxHealthPoint - currentHealthPoint) > 1f;
        }

        public void KillCharacter()
        {
            if(this.tag == "Player"){
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int oldIndex = PlayerPrefs.GetInt("index");
            if(currentIndex > oldIndex){
                PlayerPrefs.SetInt("index",currentIndex);
            }
            SceneManager.LoadScene(1);
            }
            else{
                Destroy(this.gameObject);
            }
        }
        
        public bool IsDead()
        {
            return currentHealthPoint <= 0;
        }
    }
}

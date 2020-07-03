using System;
using UnityEngine;

namespace Genki.Control
{
    public class HealthBarControl : MonoBehaviour
    {
        float healthPercentage = 1.0f;
        private Vector2 originalScale = Vector2.one;

        private void Start()
        {
            originalScale = transform.GetChild(0).localScale;
        }

        void Update()
        {
            transform.GetChild(0).localScale = new Vector3(originalScale.x * healthPercentage, originalScale.y, 1);
        }

        public void setHealth(float updatedHealth)
        {
            healthPercentage = updatedHealth;
        }
    }
}

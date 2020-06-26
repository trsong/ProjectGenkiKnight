using UnityEngine;

namespace Genki.Control
{
    public class HealthBarControl : MonoBehaviour
    {
        float healthPercentage = 1.0f;

        void Update()
        {
            transform.GetChild(0).localScale = new Vector3(healthPercentage, 1, 1);
        }

        public void setHealth(float updatedHealth)
        {
            healthPercentage = updatedHealth;
        }
    }
}

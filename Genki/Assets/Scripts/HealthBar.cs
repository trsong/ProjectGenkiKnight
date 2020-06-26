using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    float healthPercentage = 1.0f;

    void Update()
    {
        this.transform.GetChild(0).localScale = new Vector3(healthPercentage,1,1);
    }

    public void setHealth(float updatedHealth)
    {
        this.healthPercentage = updatedHealth;
    }
}

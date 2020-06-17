using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public CharacterControl player;

    void Update()
    {
        this.transform.GetChild(0).localScale = new Vector3(player.health/100f,1,1);
    }
}

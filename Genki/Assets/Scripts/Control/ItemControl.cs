using System.Collections;
using System.Collections.Generic;
using Genki.Abilitiy;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public Ability ability = null;
    public bool autoUsed = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            if (autoUsed)
            {
                ability.setOwner(other.gameObject);
                ability.apply(other.gameObject);
                ability.delete();
            }
            else
            {
                var abilitySystem = other.gameObject.GetComponent<AbilitySystem>();
                abilitySystem.attachAbilityToBar(ability);
            }
            Destroy(gameObject);
        }
    }
}

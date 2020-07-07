using System;
using System.Collections;
using System.Collections.Generic;
using Genki.Abilitiy;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public Ability ability = null;
    public bool autoUsed = false;
    private Ability _ability;

    private void Start()
    {
        if (ability != null)
        {
            _ability = Instantiate(ability);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            if (autoUsed)
            {
                _ability.setOwner(other.gameObject);
                _ability.apply();
                _ability.delete();
            }
            else
            {
                var abilitySystem = other.gameObject.GetComponent<AbilitySystem>();
                abilitySystem.attachAbilityToBar(_ability);
            }
            Destroy(gameObject);
        }
    }
}

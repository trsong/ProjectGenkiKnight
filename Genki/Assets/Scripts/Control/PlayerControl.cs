using Genki.Abilitiy;
using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class PlayerControl : MonoBehaviour
    {
        AbilitySystem abilitySystem;
        CharacterSystem character;
        WeaponSystem weaponSystem;
        
        void Start()
        {
            weaponSystem = GetComponent<WeaponSystem>();
            character = GetComponent<CharacterSystem>();
            abilitySystem = GetComponent<AbilitySystem>();
        }

        void BindKeyForAbility()
        {
            abilitySystem.bindKeyToAbility();
        }
    }
}
using System.Collections.Generic;
using Genki.Character;
using UnityEngine;

namespace Genki.Abilitiy
{
    [CreateAssetMenu(fileName = "New WeaponSwitchAbilityData", menuName = "WeaponSwitch Ability")]
    public class WeaponSwitchAbility: Ability
    {
        public List<GameObject> weapons;
        private int weaponIndex = 0;
        
        public override bool canApply()
        {
            return true;
        }

        protected override void activate()
        {
            if (owner != null)
            {
                var weaponSystem = owner.GetComponent<WeaponSystem>();
                var nextWeapon = weapons[weaponIndex];
                weaponSystem.EquipWeapon(nextWeapon);
                weaponIndex += 1;
                weaponIndex %= weapons.Count;
            }
        }
    }
}

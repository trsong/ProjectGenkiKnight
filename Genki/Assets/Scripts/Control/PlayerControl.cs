using System;
using Genki.Abilitiy;
using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class PlayerControl : BaseUnitControl
    {
        public Transform firePoint;

        void Update()
        {
            move();
            shoot();        
        }

        void move()
        {
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");
            characterSystem.moveCharacter(xMove, yMove);
        }

        void shoot(){
            if(Input.GetButtonDown("Fire1")){
                weaponSystem.shoot(firePoint);
            }
        }
        
        void BindKeyForAbility()
        {
            abilitySystem.bindKeyToAbility();
        }
    }
}
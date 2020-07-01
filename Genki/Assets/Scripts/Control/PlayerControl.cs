using System;
using Genki.Abilitiy;
using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class PlayerControl : BaseUnitControl
    {
        public Transform firePoint;
        public Joystick joyStick;
        public JoyButton joyButton;

        void Update()
        {
            move();
            shoot();        
        }

        void move()
        {
            float xMove = Input.GetAxis("Horizontal") + joyStick.Horizontal;
            float yMove = Input.GetAxis("Vertical") + joyStick.Vertical;
            characterSystem.moveCharacter(xMove, yMove);
        }

        void shoot(){
            // if(Input.GetButtonDown("Fire1") || joyButton.pressed){
            if(joyButton.pressed){
                weaponSystem.shoot(firePoint);
            }
        }
        
        void BindKeyForAbility()
        {
            abilitySystem.bindKeyToAbility();
        }
    }
}
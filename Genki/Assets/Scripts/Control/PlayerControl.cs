using System;
using Genki.Abilitiy;
using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class PlayerControl : BaseUnitControl
    {
        public Transform firePoint;
        protected Joystick joyStick;
        protected JoyButton joyButton;

        private bool isShootingPressed = false;

        protected override void Start()
        {
            base.Start();
            joyStick = FindObjectOfType<Joystick>();
            joyButton = FindObjectOfType<JoyButton>();
            
            GameObject healthBar = GameObject.FindWithTag("PlayerHealthBar");
            healthSystem.healthBar = healthBar.GetComponent<HealthBarControl>();
        }

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
            // TODO: Remove fire button shoot after build
            if (Input.GetButtonDown("Fire2"))
            {
                isShootingPressed = !isShootingPressed;
            }

            if (isShootingPressed || Input.GetButtonDown("Fire1") || joyButton.pressed)
            {
                weaponSystem.shoot(firePoint);
                
            }

            if(joyButton.pressed){
                joyButton.SetUnPressed();
                weaponSystem.shoot(firePoint);
            }
        }
        
        void BindKeyForAbility()
        {
            abilitySystem.bindKeyToAbility();
        }
    }
}
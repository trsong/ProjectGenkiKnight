using System;
using Genki.Abilitiy;
using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class PlayerControl : BaseUnitControl
    {
        public Transform firePoint;
        protected Joystick joyStickLeft;
        protected Joystick joyStickRight;

        private bool isShootingPressed = false;

        protected override void Start()
        {
            base.Start();
            joyStickLeft = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
            joyStickRight = GameObject.Find("Fixed Joystick Right").GetComponent<Joystick>();
            
            GameObject healthBar = GameObject.FindWithTag("PlayerHealthBar");
            healthSystem.healthBar = healthBar.GetComponent<HealthBarControl>();
            abilitySystem.bindKeyToAbility();
        }

        void Update()
        {
            move();
            shoot();        
        }

        void move()
        {
            float xMove = Input.GetAxis("Horizontal") + joyStickLeft.Horizontal;
            float yMove = Input.GetAxis("Vertical") + joyStickLeft.Vertical;
            characterSystem.moveCharacter(xMove, yMove);
        }

        void shoot(){
            // TODO: Remove fire button shoot after build
            if (Input.GetButtonDown("Fire2"))
            {
                isShootingPressed = !isShootingPressed;
            }

            // Debug.Log(joyStickRight.Horizontal);

            if (isShootingPressed || Input.GetButtonDown("Fire1") || 
                joyStickRight.Horizontal * joyStickRight.Horizontal + joyStickRight.Vertical * joyStickRight.Vertical >= 0.04f)
            {
                weaponSystem.shoot(firePoint);
            }

        }

    }
}
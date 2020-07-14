using System;
using Genki.Abilitiy;
using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class PlayerControl : BaseUnitControl
    {
        public Transform firePoint;

        private bool isShootingPressed = false;

        protected override void Start()
        {
            base.Start();
            
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
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");
            characterSystem.moveCharacter(xMove, yMove);
        }

        void shoot(){
            // TODO: Remove fire button shoot after build
            if (Input.GetButtonDown("Fire2"))
            {
                isShootingPressed = !isShootingPressed;
            }

            // Debug.Log(joyStickRight.Horizontal);

            if (isShootingPressed || Input.GetButtonDown("Fire1"))
            {
                weaponSystem.shoot(firePoint);
            }

        }

    }
}
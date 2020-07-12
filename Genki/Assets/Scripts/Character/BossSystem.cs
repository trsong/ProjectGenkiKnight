using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genki.Character
{
    public class BossSystem : CharacterSystem
    {
        public Animator a;
        public Transform enemyPos;
        protected WeaponSystem weaponSystem;
        protected HealthSystem healthSystem;
        public GameObject weapon;
        public int range;
        public GameObject attackTarget = null;
        public bool isAttack = false;


        private int Timer = 0;

        void Start()
        {
            weaponSystem = GetComponent<WeaponSystem>();
            healthSystem = GetComponent<HealthSystem>();
            if (attackTarget == null)
            {
                attackTarget = GameObject.FindWithTag("Player");
            }
        }

        void Update()
        {
            Timer++;
            a = GetComponent<Animator>();
            
            if(Vector3.Distance(attackTarget.transform.position, enemyPos.transform.position) <= range && !isAttack)
            {
                isAttack = true;
            }

            if (Timer % 150 == 0 && isAttack)
            {
                attack();
            }

            if(healthSystem.currentHealthPoint <= healthSystem.maxHealthPoint / 2)
            {
                weaponSystem.EquipWeapon(this.weapon);
            }
        }

        void FixedUpdate()
        {
            //null
        }

        void attack()
        {
            weaponSystem.shootBoss(enemyPos.transform);
        }
    }

}


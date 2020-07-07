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

        private int Timer = 0;

        void Start()
        {
            weaponSystem = GetComponent<WeaponSystem>();   
        }

        void Update()
        {
            Timer++;
            a = GetComponent<Animator>();
            
            if (Timer % 150 == 0)
            {
                attack();
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


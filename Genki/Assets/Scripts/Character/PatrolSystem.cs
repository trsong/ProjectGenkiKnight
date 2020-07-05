using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genki.Character
{
    public class PatrolSystem : CharacterSystem
    {
        public Animator a;
        public Transform enemyPos;
        public int minRange;
        public int maxRange;
        public int attackRange;
        public GameObject attackTarget = null;
        public float offset;
        public bool xORy = true;
        public bool patrol_mode = true;
        protected WeaponSystem weaponSystem;

        private int Timer = 0;
        Vector3 endPos;

        void Start()
        {
            weaponSystem = GetComponent<WeaponSystem>();
            if (attackTarget == null)
            {
                attackTarget = GameObject.FindWithTag("Player");
            }
            if (xORy)
            {
                endPos.x = enemyPos.transform.position.x + offset;
                endPos.y = enemyPos.transform.position.y;
                endPos.z = enemyPos.position.z;
            }
            else
            {
                endPos.x = enemyPos.transform.position.x;
                endPos.y = enemyPos.transform.position.y + offset;
                endPos.z = enemyPos.transform.position.z;
            }
        }


        void Update()
        {
            Timer++;
            a = GetComponent<Animator>();
            if (attackTarget == null)
            {
                attackTarget = GameObject.FindWithTag("Player");
            }
            if (Vector3.Distance(attackTarget.transform.position, transform.position) <= maxRange && Vector3.Distance(attackTarget.transform.position, transform.position) >= minRange)
            {
                patrol_mode = false;
                if (Vector3.Distance(attackTarget.transform.position, transform.position) <= attackRange)
                {
                    if (Timer % 150 == 0)
                    {
                        attack();
                    }
                }
                else
                {
                    followPlayer();
                }
            }
            else if (Vector3.Distance(attackTarget.transform.position, transform.position) > maxRange)
            {
                goBack();
            }
        }

        private void FixedUpdate()
        {
            //null
        }

        public void Patrol()
        {
            if(Vector3.Distance(transform.position, enemyPos.transform.position) == 0)
            {
                a.SetBool("isAttacking", false);
                a.SetBool("isMoving", true);
                Vector2 movePos = Correction((endPos.x - transform.position.x), (endPos.y - transform.position.y));
                a.SetFloat("moveX", movePos.x);
                a.SetFloat("moveY", movePos.y);
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            }else if(Vector3.Distance(transform.position, endPos) == 0)
            {
                
                a.SetBool("isAttacking", false);
                a.SetBool("isMoving", true);
                Vector2 movePos = Correction((enemyPos.transform.position.x - transform.position.x), (enemyPos.transform.position.y - transform.position.y));
                a.SetFloat("moveX", movePos.x);
                a.SetFloat("moveY", movePos.y);
                transform.position = Vector3.MoveTowards(transform.position, enemyPos.transform.position, speed * Time.deltaTime);
            }
            else
            {
                if((a.GetFloat("moveX") == 0 && a.GetFloat("moveY") == -1) || (a.GetFloat("moveX") == -1 && a.GetFloat("moveY") == 0))
                {
                    transform.position = Vector3.MoveTowards(transform.position, enemyPos.transform.position, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
                }
            }
        }

        public void followPlayer()
        {
            a.SetBool("isAttacking", false);
            a.SetBool("isMoving", true);
            Vector2 movePos = Correction((attackTarget.transform.position.x - transform.position.x), (attackTarget.transform.position.y - transform.position.y));
            a.SetFloat("moveX", movePos.x);
            a.SetFloat("moveY", movePos.y);
            transform.position = Vector3.MoveTowards(transform.position, attackTarget.transform.position, speed * Time.deltaTime);
        }

        public void goBack()
        {
            if (patrol_mode)
            {
                Patrol();
            }
            else
            {
                a.SetBool("isAttacking", false);
                a.SetBool("isMoving", true);
                Vector2 movePos = Correction((enemyPos.transform.position.x - transform.position.x), (enemyPos.transform.position.y - transform.position.y));
                a.SetFloat("moveX", movePos.x);
                a.SetFloat("moveY", movePos.y);
                transform.position = Vector3.MoveTowards(transform.position, enemyPos.transform.position, speed * Time.deltaTime);
                if (Vector3.Distance(enemyPos.transform.position, transform.position) == 0)
                {
                    //Patrol();
                    a.SetBool("isMoving", false);
                    patrol_mode = true;
                }
            }
            
        }
        public void attack()
        {
            a.SetBool("isMoving", false);
            a.SetBool("isAttacking", true);
            Vector2 movePos = Correction((attackTarget.transform.position.x - transform.position.x), (attackTarget.transform.position.y - transform.position.y));
            a.SetFloat("moveX", movePos.x);
            a.SetFloat("moveY", movePos.y);
            //characterSystem.moveCharacter(movePos);
            weaponSystem.shootTarget(attackTarget.transform);
        }
        public Vector2 Correction(float x, float y)
        {
            Vector2 result;
            if ((y - x <= 0) && (y + x > 0))
            {
                result.x = 1;
                result.y = 0;
            }
            else if ((y - x > 0) && (y + x > 0))
            {
                result.x = 0;
                result.y = 1;
            }
            else if ((y - x > 0) && (y + x <= 0))
            {
                result.x = -1;
                result.y = 0;
            }
            else
            {
                result.x = 0;
                result.y = -1;
            }
            return result;
        }
    }
}
   
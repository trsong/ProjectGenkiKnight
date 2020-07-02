using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class EnemyControl : BaseUnitControl
    {
        public Animator a;
        public Transform enemyPos;
        public int minRange;
        public int maxRange;
        public int attackRange;
        public GameObject attackTarget = null;

        private int Timer = 0;
        
        protected override void Start()
        {
            base.Start();
            if (!attackTarget)
            {
                attackTarget = GameObject.FindWithTag("Player");
            }
        }
        
        
        void Update()
        {
            Timer++;
            a = GetComponent<Animator>();
            if (Vector3.Distance(attackTarget.transform.position, transform.position) <= maxRange && Vector3.Distance(attackTarget.transform.position, transform.position) >= minRange)
            {
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

        public void followPlayer()
        {
            a.SetBool("isAttacking", false);
            a.SetBool("isMoving", true);
            Vector2 movePos = Correction((attackTarget.transform.position.x - transform.position.x), (attackTarget.transform.position.y - transform.position.y));
            characterSystem.moveCharacter(movePos);
        }

        public void goBack()
        {
            a.SetBool("isAttacking", false);
            a.SetBool("isMoving", true);
            Vector2 movePos = Correction((enemyPos.position.x - transform.position.x), (enemyPos.position.y - transform.position.y));
            characterSystem.moveCharacter(movePos);
            if (Vector3.Distance(enemyPos.position, transform.position) == 0)
            {
                a.SetBool("isMoving", false);
            }
        }
        public void attack()
        {
            a.SetBool("isMoving", false);
            a.SetBool("isAttacking", true);
            Vector2 movePos = Correction((attackTarget.transform.position.x - transform.position.x), (attackTarget.transform.position.y - transform.position.y));
            characterSystem.moveCharacter(movePos);
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

using Genki.Character;
using UnityEngine;

namespace Genki.Control
{
    public class EnemyControl : BaseUnitControl
    {
        public Transform enemyPos;
        public int minRange;
        public int maxRange;
        public GameObject attackTarget = null;

        void Update()
        {
            var target = attackTarget.transform;
            if (Vector3.Distance(target.position, transform.position) <= maxRange &&
                Vector3.Distance(target.position, transform.position) >= minRange)
            {
                followPlayer();
            }else if(Vector3.Distance(target.position, transform.position) > maxRange)
            {
                goBack();
            }
        }

        public void followPlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, attackTarget.transform.transform.position,
                characterSystem.speed * Time.deltaTime);
        }

        public void goBack()
        {
            transform.position = Vector3.MoveTowards(transform.position, enemyPos.position,
                characterSystem.speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

namespace Genki.Character
{
    public enum EnemyType { Player, NPC, Skeleton, Archer, Boss, Elite };

    public class CharacterSystem : MonoBehaviour
    {
        public EnemyType enemyType = EnemyType.Player;
        public bool canAttack = true;
        public bool canInteract = false;
        
        public float speed = 5f;
        public Rigidbody2D rigidbody;
        public Animator animator = null;
        
        Vector2 move;
        
        void Update()
        {
            if (animator)
            {
                animator.SetFloat("Hor", move.x); 
                animator.SetFloat("Ver", move.y);
            }
        }

        void FixedUpdate()
        {
            if (rigidbody)
            {
                rigidbody.MovePosition(rigidbody.position + move*speed * Time.fixedDeltaTime);
            }
        }

        public bool isEnemy()
        {
            return enemyType != EnemyType.Player & enemyType != EnemyType.NPC;
        }

        public void moveCharacter(float x, float y)
        {
            move.x = x;
            move.y = y;
        }
    }
}

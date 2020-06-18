using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Genki.Character
{
    public enum EnemyType { Player, NPC, Skeleton, Archer, Boss, Elite };

    public class CharacterSystem : MonoBehaviour
    {
        
        public float moveSpeed  = 5f;
        public EnemyType enemyType = EnemyType.Player;
        public bool canAttack = true;
        public bool canInteract = false;

        public bool isEnemy()
        {
            return enemyType != EnemyType.Player & enemyType != EnemyType.NPC;
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

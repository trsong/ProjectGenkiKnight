using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

namespace Genki.Character
{
    public class CharacterSystem : MonoBehaviour
    {
        public bool canAttack = true;
        public bool canInteract = false;
        
        public float speed = 5f;
        
        private Animator animator = null;
        private Rigidbody2D charRigidbody = null;
        Vector2 move;

        void Start()
        {
            charRigidbody = gameObject.GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            animator.SetFloat("moveX", move.x); 
            animator.SetFloat("moveY", move.y);
        }

        void FixedUpdate()
        {
            charRigidbody.MovePosition(charRigidbody.position + move*speed * Time.fixedDeltaTime);
        }

        public bool isEnemy()
        {
            return transform.CompareTag("Enemy");
        }

        public void moveCharacter(float x, float y)
        {
            move.x = x;
            move.y = y;
        }

        public void moveCharacter(Vector2 pos)
        {
            move.x = pos.x;
            move.y = pos.y;
        }
    }
}

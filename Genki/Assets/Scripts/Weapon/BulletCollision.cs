using System;
using Genki.Control;
using UnityEngine;
using Genki.Character;

namespace Genki.Weapon
{
    public class BulletCollision : MonoBehaviour
    {
        private Vector2 startPosition = Vector2.zero ;
        private float maxDistance = 0f;
        private IUnitControl owner = null;

        public void setOwner(IUnitControl newOwner)
        {
            owner = newOwner;
            var weapon = newOwner.getWeaponSystem().weapon;
            maxDistance = weapon.GetComponent<WeaponConfig>().maxAttackRange;
            startPosition = newOwner.getStartPosition();
        }

        public IUnitControl getOwner()
        {
            return owner;
        }

        void Update()
        {
            if (startPosition != Vector2.zero && Vector2.Distance(startPosition, gameObject.transform.position) > maxDistance)
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 2);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Bullet" && other.tag != "searcher")
            {
                Destroy(gameObject);
            }
            
        }

    }
}
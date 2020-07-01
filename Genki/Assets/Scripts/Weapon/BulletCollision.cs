using Genki.Control;
using UnityEngine;
using Genki.Character;

namespace Genki.Weapon
{
    public class BulletCollision : MonoBehaviour
    {
        public IUnitControl owner = null;

        public void setOwner(IUnitControl newOwner)
        {
            owner = newOwner;
        }

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 2);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Bullet")
            {
                Destroy(gameObject);
            }
            
        }

    }
}
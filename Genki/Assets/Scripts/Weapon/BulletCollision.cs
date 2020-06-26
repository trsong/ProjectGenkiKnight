using Genki.Control;
using UnityEngine;

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
    
        void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    
    }
}


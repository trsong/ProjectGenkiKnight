using System.Collections;
using System.Collections.Generic;
using Genki.Control;
using UnityEngine;

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
        if(other.gameObject.tag.Equals("Enemy")){
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

}

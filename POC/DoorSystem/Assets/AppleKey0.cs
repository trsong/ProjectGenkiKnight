using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleKey0 : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D other)
    {
        KeyManagement.current.collectKey(id);
        Object.Destroy(this.gameObject);
    }
}

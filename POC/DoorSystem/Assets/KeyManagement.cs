using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagement : MonoBehaviour
{
    public static KeyManagement current;

    public void Awake()
    {
        current = this;
    }

    private Dictionary<int, int> ownKeys = new Dictionary<int, int>();

    public void collectKey(int key)
    {
        if (!ownKeys.ContainsKey(key))
            ownKeys[key] = 0;
        ownKeys[key]++;
    }
    
    public bool hasKey(int key)
    {
        return (ownKeys.ContainsKey(key) && ownKeys[key] > 0);
    }

    public void useKey(int key)
    {
        ownKeys[key]--;
    }
}

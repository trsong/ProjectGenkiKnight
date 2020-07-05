using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyManagement : MonoBehaviour
{
    public static DoorKeyManagement current;
    private int nextID;

    public void Awake()
    {
        current = this;
        nextID = 0;
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

    public int getNextID()
    {
        return nextID++;
    }
}

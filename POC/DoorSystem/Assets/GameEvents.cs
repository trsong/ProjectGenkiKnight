using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public void Awake()
    {
        current = this;
    }

    private Dictionary<int, List<int>> scenesDoors = new Dictionary<int, List<int>>();
    
    public event Action<int> onDoorwayTriggerEnter;
    public void DoorwayTriggerEnter(int id)
    {
        if (onDoorwayTriggerEnter != null && KeyManagement.current.hasKey(id))
        {
            KeyManagement.current.useKey(id);
            onDoorwayTriggerEnter(id);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    public static DoorEvents current;

    public void Awake()
    {
        current = this;
    }

    private Dictionary<int, List<int>> scenesDoors = new Dictionary<int, List<int>>();
    
    public event Action<int> onDoorwayTriggerEnter;
    public void DoorwayTriggerEnter(int id)
    {
        if (onDoorwayTriggerEnter != null && DoorKeyManagement.current.hasKey(id))
        {
            DoorKeyManagement.current.useKey(id);
            onDoorwayTriggerEnter(id);
        }
    }
}

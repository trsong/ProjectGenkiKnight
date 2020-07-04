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

    // private Dictionary<int, List<int>> scenesDoors = new Dictionary<int, List<int>>();
    
    public event Action<int> onDoorwayTriggerEnter;
    public event Action<int> onDoorwayTriggerExit;
    // for opening door
    public void DoorwayTriggerEnter(int id)
    {
        if (onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter(id);
        }
    }
    // for closing door
    public void DoorwayTriggerExit(int id)
    {
        if (onDoorwayTriggerExit != null)
        {
            onDoorwayTriggerExit(id);
        }
    }
}

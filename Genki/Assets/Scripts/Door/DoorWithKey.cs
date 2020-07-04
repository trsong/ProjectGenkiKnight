using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public int id;

    void Start()
    {
        id = DoorKeyManagement.current.getNextID();
        GetComponentInChildren<DoorController>().id = id;
        GetComponentInChildren<DoorKey>().id = id;
        GetComponentInChildren<DoorTriggerArea>().id = id;
    }

}

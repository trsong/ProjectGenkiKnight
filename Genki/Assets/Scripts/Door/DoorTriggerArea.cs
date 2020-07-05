using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (DoorKeyManagement.current.hasKey(id))
            {
                DoorKeyManagement.current.useKey(id);
                DoorEvents.current.DoorwayTriggerEnter(id);
            }
        }
    }
}

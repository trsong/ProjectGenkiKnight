using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEvents.current.DoorwayTriggerEnter(id);
    }
}

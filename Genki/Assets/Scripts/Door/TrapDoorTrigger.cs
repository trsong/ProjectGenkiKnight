using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorTrigger : MonoBehaviour
{
    private List<int> doorIDs;
    private List<GameObject> nearEnemies;
    float interval = 1f;
    float nextTime = 0f;

    void Start()
    {
        doorIDs = new List<int>();
        nearEnemies = new List<GameObject>();
        DoorController[] doors = GetComponentsInChildren<DoorController>();
        for (int i = 0; i < doors.Length; i++) {
            int id = DoorKeyManagement.current.getNextID();
            doors[i].id = id;
            doorIDs.Add(id);
        }
    }
    void Update()
    {
        if (Time.time >= nextTime)
        {
            for (int i = nearEnemies.Count - 1; i >= 0; i--)
            {
                if (nearEnemies[i] == null)
                {
                    nearEnemies.RemoveAt(i);
                }
            }
            if (nearEnemies.Count == 0) 
            {
                foreach(int id in doorIDs)
                {
                    DoorEvents.current.DoorwayTriggerEnter(id);
                }
            }
            nextTime += interval;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && nearEnemies.Count > 0)
        {
            foreach(int id in doorIDs)
            {
                DoorEvents.current.DoorwayTriggerExit(id);
            }
        } else if (other.tag == "Enemy")
        {
            nearEnemies.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            nearEnemies.Remove(collision.gameObject);
        }
    }
}

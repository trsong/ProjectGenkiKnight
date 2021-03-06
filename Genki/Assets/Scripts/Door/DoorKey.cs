﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DoorKeyManagement.current.collectKey(id);
            Object.Destroy(this.gameObject);
        }
    }
}

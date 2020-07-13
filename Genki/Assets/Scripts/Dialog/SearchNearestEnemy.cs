using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchNearestEnemy : MonoBehaviour
{
    private GameObject player;
    private List<GameObject> nearEnemies;
    private GameObject nearestEnemy;

    void Start()
    {
        player = GameObject.Find("Player");
        nearestEnemy = null;
        nearEnemies = new List<GameObject>();
    }

    void FixedUpdate()
    {
        transform.position = player.transform.position;
        nearestEnemy = null;
        if (nearEnemies.Count > 0)
        {
            float distance = 1e9f;
            foreach (GameObject e in nearEnemies)
            {
                if (e != null && Vector3.Distance(transform.position, e.transform.position) < distance)
                {
                    nearestEnemy = e;
                }
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Enemy"))
        {
            nearEnemies.Add(other);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            nearEnemies.Remove(collision.gameObject);
        }
    }
    public GameObject getNearestEnemy()
    {
        return nearestEnemy;
    }
}

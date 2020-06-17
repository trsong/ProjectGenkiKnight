using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public Transform enemyPos;
    public float speed;
    public int minRange;
    public int maxRange;


    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            followPlayer();
        }else if(Vector3.Distance(target.position, transform.position) > maxRange)
        {
            goBack();
        }
    }

    public void followPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void goBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyPos.position, speed * Time.deltaTime);
    }

}

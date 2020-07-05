using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingAnimation : MonoBehaviour
{
    public GameObject player;
    public GameObject chicken;
    private Vector2 ChickenMove = new Vector2(0,0),PLayerMove = new Vector2(0,0);
    private float speed = 5,dis = 0.1f;
    void Update()
    {
        chicken.transform.Translate(ChickenMove * Time.deltaTime *speed);
        player.transform.Translate(PLayerMove * Time.deltaTime*speed);
        if(Vector3.Distance(chicken.transform.position , new Vector3(-7,3,0)) < dis ){
            chicken.GetComponent<Animator>().SetFloat("moveY",0);
            chicken.GetComponent<Animator>().SetFloat("moveX",1);
            ChickenMove = Vector2.right;
        }
        if(Vector3.Distance(chicken.transform.position , new Vector3(7,3,0)) < dis ){
            chicken.GetComponent<Animator>().SetFloat("moveY",-1);
            chicken.GetComponent<Animator>().SetFloat("moveX",0);
            ChickenMove = Vector2.down;
        }
        if(Vector3.Distance(chicken.transform.position , new Vector3(7,-3,0)) < dis ){
            chicken.GetComponent<Animator>().SetFloat("moveX",-1);
            chicken.GetComponent<Animator>().SetFloat("moveY",0);
            ChickenMove = Vector2.left;
        }
        if(Vector3.Distance(chicken.transform.position , new Vector3(-7,-3,0)) < dis ){
            chicken.GetComponent<Animator>().SetFloat("moveY",1);
            chicken.GetComponent<Animator>().SetFloat("moveX",0);
            ChickenMove = Vector2.up;
        }if(Vector3.Distance(player.transform.position , new Vector3(-7,-3,0)) < dis ){
            player.GetComponent<Animator>().SetFloat("moveX",0);
            player.GetComponent<Animator>().SetFloat("moveY",1);
            PLayerMove = Vector2.up;
        }
        if(Vector3.Distance(player.transform.position , new Vector3(-7,3,0)) < dis ){
            player.GetComponent<Animator>().SetFloat("moveY",0);
            player.GetComponent<Animator>().SetFloat("moveX",1);            
            PLayerMove = Vector2.right;
        }
        if(Vector3.Distance(player.transform.position , new Vector3(7,3,0)) < dis ){
            player.GetComponent<Animator>().SetFloat("moveX",0);
            player.GetComponent<Animator>().SetFloat("moveY",-1);            
            PLayerMove = Vector2.down;
        }
        if(Vector3.Distance(player.transform.position , new Vector3(7,-3,0)) < dis ){
            player.GetComponent<Animator>().SetFloat("moveY",0);
            player.GetComponent<Animator>().SetFloat("moveX",-1);            
            PLayerMove = Vector2.left;
        }
    }
}

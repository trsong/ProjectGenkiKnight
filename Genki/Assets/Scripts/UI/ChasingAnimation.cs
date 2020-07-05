using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingAnimation : MonoBehaviour
{
    public GameObject chaser;
    public GameObject runner;
    private Vector2 ChickenMove = new Vector2(0,0),PLayerMove = new Vector2(0,0);
    private float speed = 5,dis = 0.1f;
    void Update()
    {
        runner.transform.Translate(ChickenMove * Time.deltaTime *speed);
        chaser.transform.Translate(PLayerMove * Time.deltaTime*speed);
        if(Vector3.Distance(runner.transform.position , new Vector3(-7,3,0)) < dis ){
            runner.GetComponent<Animator>().SetFloat("moveY",0);
            runner.GetComponent<Animator>().SetFloat("moveX",1);
            ChickenMove = Vector2.right;
        }
        if(Vector3.Distance(runner.transform.position , new Vector3(7,3,0)) < dis ){
            runner.GetComponent<Animator>().SetFloat("moveY",-1);
            runner.GetComponent<Animator>().SetFloat("moveX",0);
            ChickenMove = Vector2.down;
        }
        if(Vector3.Distance(runner.transform.position , new Vector3(7,-3,0)) < dis ){
            runner.GetComponent<Animator>().SetFloat("moveX",-1);
            runner.GetComponent<Animator>().SetFloat("moveY",0);
            ChickenMove = Vector2.left;
        }
        if(Vector3.Distance(runner.transform.position , new Vector3(-7,-3,0)) < dis ){
            runner.GetComponent<Animator>().SetFloat("moveY",1);
            runner.GetComponent<Animator>().SetFloat("moveX",0);
            ChickenMove = Vector2.up;
        }if(Vector3.Distance(chaser.transform.position , new Vector3(-7,-3,0)) < dis ){
            chaser.GetComponent<Animator>().SetFloat("moveX",0);
            chaser.GetComponent<Animator>().SetFloat("moveY",1);
            PLayerMove = Vector2.up;
        }
        if(Vector3.Distance(chaser.transform.position , new Vector3(-7,3,0)) < dis ){
            chaser.GetComponent<Animator>().SetFloat("moveY",0);
            chaser.GetComponent<Animator>().SetFloat("moveX",1);            
            PLayerMove = Vector2.right;
        }
        if(Vector3.Distance(chaser.transform.position , new Vector3(7,3,0)) < dis ){
            chaser.GetComponent<Animator>().SetFloat("moveX",0);
            chaser.GetComponent<Animator>().SetFloat("moveY",-1);            
            PLayerMove = Vector2.down;
        }
        if(Vector3.Distance(chaser.transform.position , new Vector3(7,-3,0)) < dis ){
            chaser.GetComponent<Animator>().SetFloat("moveY",0);
            chaser.GetComponent<Animator>().SetFloat("moveX",-1);            
            PLayerMove = Vector2.left;
        }
    }
}

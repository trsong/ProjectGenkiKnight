using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{
    public int health = 100;

    public void damaged(int damage){
        health-=damage;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Enemy"){
            damaged(10);
        }
        Debug.Log(health);
        if(other.transform.tag == "scene")
        {
            SceneManager.LoadScene("four");
            Debug.Log(1);
        }
    }

}

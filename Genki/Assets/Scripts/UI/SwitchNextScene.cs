using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchNextScene : MonoBehaviour
{
    public Animator transition;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

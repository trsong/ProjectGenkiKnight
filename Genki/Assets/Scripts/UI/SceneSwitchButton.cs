using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitchButton : MonoBehaviour
{
    public Animator transition;
    public void SwitchScene ()
    {
        StartCoroutine(switchNext());
    }
    IEnumerator switchNext(){
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}

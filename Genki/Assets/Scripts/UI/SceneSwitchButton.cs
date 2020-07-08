using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitchButton : MonoBehaviour
{
    public Animator transition;
    public void SwitchSceneToStart()
    {
        StartCoroutine(SwitchToStart());
    }
    IEnumerator SwitchToStart()
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
    public void SwitchSceneToDeadLevel()
    {
        StartCoroutine(SwitchToDeadLevel());
    }
    IEnumerator SwitchToDeadLevel()
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(PlayerPrefs.GetInt("index"));
    }
    public void SwitchSceneToFirstLevel()
    {
        StartCoroutine(SwitchToFirstLevel());
    }
    IEnumerator SwitchToFirstLevel()
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("index", 0);
        SceneManager.LoadScene(2);
    }
}

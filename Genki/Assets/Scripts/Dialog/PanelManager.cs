using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONFactory;
using UnityEngine.SceneManagement;


public class PanelManager : MonoBehaviour,IManager {
    public ManagerState currentState { get; private set; }
    private PanelConfig rightPanel;
    private PanelConfig leftPanel;
    private NarrativeEvent currentEvent;
    private int stepIndex = 0;
    public void BootSequence()
    {
        Debug.Log(string.Format("{0} is booting up", GetType().Name));
        rightPanel = GameObject.Find("RightCharacterPanel").GetComponent<PanelConfig>();
        leftPanel = GameObject.Find("LeftCharacterPanel").GetComponent<PanelConfig>();

        var sceneId = SceneManager.GetActiveScene().buildIndex;
        currentEvent = JSONAssembly.RunJSONFactoryForScene(sceneId);
        InitializePanels();
        Debug.Log(string.Format("{0} status ={1}", GetType().Name, currentState));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdatePanelState();
        }
    }
    private void InitializePanels()
    {
        leftPanel.characterIsTalking = true;
        rightPanel.characterIsTalking = false;
        leftPanel.Configure(currentEvent.dialogues[stepIndex]);
        rightPanel.Configure(currentEvent.dialogues[stepIndex + 1]);
        StartCoroutine(MasterManager.animationManager.IntroAnimation());
        stepIndex++;
    }


    private void ConfigurePanels()
    {
        var currentDialog = currentEvent.dialogues[stepIndex];
        if (currentDialog.leftSide)
        {
            leftPanel.characterIsTalking = true;
            rightPanel.characterIsTalking = false;
            leftPanel.Configure(currentDialog);
            rightPanel.ToggleCharacterMask();
        }
        else
        {
            leftPanel.characterIsTalking = false;
            rightPanel.characterIsTalking = true;
            leftPanel.ToggleCharacterMask(); 
            rightPanel.Configure(currentDialog);
        }
    }
    void UpdatePanelState()
    {
        if (stepIndex < currentEvent.dialogues.Count)
        {
            ConfigurePanels();
            stepIndex++;
        }
        else
        {
            StartCoroutine(MasterManager.animationManager.ExitAnimation());
            StartCoroutine(NextScene());
        }
    }
    
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1f);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONFactory;

public class Test : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        NarrativeEvent testEvent = JSONAssembly.RunJSONFactoryForScene(1);
        Debug.Log(testEvent.dialogues[0].characterType);
    }
    //Update is called once per frame
    void Update()
    {

    }


}

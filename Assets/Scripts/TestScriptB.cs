using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptB : MonoBehaviour
{
    public string testString;

    private void Awake()
    {
        TestScriptA script = GetComponent<TestScriptA>(); ;
        script.GetString += ReturnString;
        script.LogString();
    }

    string ReturnString()
    {
        return testString;
    }
}

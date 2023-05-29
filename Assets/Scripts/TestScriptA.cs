using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptA : MonoBehaviour
{
    public delegate string StringCheck();
    public StringCheck GetString;

    public void LogString()
    {
        Debug.Log("Script B's string is equal to..." + GetString.Invoke());
    }
}

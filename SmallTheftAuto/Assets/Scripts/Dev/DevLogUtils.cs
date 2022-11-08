using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DevLogUtils : Editor
{
    [MenuItem("Dev Utils/Log Active")]
    public static void LogSelection()
    {
        var activeObj = Selection.activeObject;
        
        if (activeObj != null)
            Debug.Log(activeObj);
    }
    
}

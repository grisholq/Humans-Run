using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResourcesTest
{
    //[MenuItem("Hoopsly/ResourcesCheck")]
    public static void CheckResources()
    {
        HoopslySettings hoopslySettings = Resources.Load("HoopslySettings") as HoopslySettings;
        if(hoopslySettings==null)
        {
            Debug.Log("Settings file not found!");
        }
        else
        {
            Debug.Log("Settings file was found!");
            //Debug.Log(hoopslySettings.m_maxSdkKey);
        }
    }
}

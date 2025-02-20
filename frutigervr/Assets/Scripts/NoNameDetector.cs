using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoNameDetector : MonoBehaviour
{
    public NameScript NameScript;
    public GameObject ObjectToToggle;

    void Update()
    {
        if(NameScript.NameVar == "")
        {
            ObjectToToggle.SetActive(true);
        }
        else
        {
            ObjectToToggle.SetActive(false);
        }
    }
}

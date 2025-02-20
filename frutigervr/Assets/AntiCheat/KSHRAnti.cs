using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class KSHRAnti : MonoBehaviour
{
    public string[] assembliesToCheck = new string[4]
    {
        "melon",
        "lemon",
        "harmony",
        "devx"
    };

    public bool quitApp = true;

    public bool destroyGameObjs = true;

    public bool disconnectFromPhoton = true;

    public int quitErrorCode = 404;

    public void Start()
    {
        name = "KSHRANTI";
        CheckAssemblies();
    }

    private void CheckAssemblies()
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (Assembly asdasdasddwwd in assemblies)
        {
            if (assembliesToCheck.Contains(asdasdasddwwd.FullName.ToLower()) || assembliesToCheck.Contains(asdasdasddwwd.FullName.ToUpper()) || assembliesToCheck.Contains(asdasdasddwwd.FullName))
            {
                if(disconnectFromPhoton)
                {
                    if (PhotonNetwork.IsConnected)
                    {
                        PhotonNetwork.Disconnect();
                    }
                }
                if(destroyGameObjs)
                {
                    GameObject[] gameObjects = FindObjectsOfType<GameObject>();
                    foreach (GameObject gulp in gameObjects)
                    {
                        if (gulp.name != "KSHRANTI")
                        {
                            Destroy(gulp);
                        }
                    }
                }
                if (quitApp)
                {
#if UNITY_ANDROID
                Application.Quit(quitErrorCode);
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                    .GetStatic<AndroidJavaObject>("currentActivity");

                if (activity != null)
                {
                    activity.Call("finish");
                }
                else
                {
                    Debug.LogError("Failed to get current activity");
                }
#else
                    Application.Quit(quitErrorCode);
                #endif
                }
            }
        }
    }
}
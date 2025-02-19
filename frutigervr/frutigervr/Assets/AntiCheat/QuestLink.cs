using UnityEngine;
using System.IO;
using System.Diagnostics; // Add this line for Process class
using Photon.Pun;

public class QuestLink : MonoBehaviourPunCallbacks
{
    [Header("Folder Detection")]
    public string[] foldersToCheck;

    [Header("Actions to Take")]
    public bool disconnectFromPhoton = true;
    public bool destroyAllGameObjects = true;
    public bool quitApplication = true;

    [Header("Additional Actions")]
    public bool unloadUnusedAssets = true;
    public bool printFoldersExist = true;

    [Header("Detect External Applications")]
    public string[] externalApplicationsToDetect;

    private void Start()
    {
        string gameDirectory = Application.dataPath;
        bool anyFolderExists = false;

        foreach (string folderToCheck in foldersToCheck)
        {
            string folderPath = Path.Combine(gameDirectory, folderToCheck);

            if (Directory.Exists(folderPath))
            {
                anyFolderExists = true;

                if (printFoldersExist)
                {
                    UnityEngine.Debug.Log($"Folder '{folderToCheck}' exists.");
                }

                if (disconnectFromPhoton)
                {
                    DisconnectFromPhoton();
                }

                if (destroyAllGameObjects)
                {
                    DestroyAllGameObjects();
                }

                if (quitApplication)
                {
                    QuitApplication();
                }

                if (unloadUnusedAssets)
                {
                    UnloadUnusedAssets();
                }
            }
        }

        if (!anyFolderExists && printFoldersExist)
        {
            UnityEngine.Debug.Log("None of the specified folders exist.");
        }

        DetectExternalApplications();
    }

    private void DisconnectFromPhoton()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }

    private void DestroyAllGameObjects()
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject go in gameObjects)
        {
            if (go != gameObject)
            {
                Destroy(go);
            }
        }
    }

    private void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
            .GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call("finish");
#else
        Application.Quit();
#endif
    }

    private void UnloadUnusedAssets()
    {
        Resources.UnloadUnusedAssets();
    }

    private void DetectExternalApplications()
    {
        foreach (string appName in externalApplicationsToDetect)
        {
            Process[] processes = Process.GetProcessesByName(appName);

            if (processes.Length > 0)
            {
                UnityEngine.Debug.LogWarning($"{appName} is running. Please close it to proceed.");
            }
        }
    }
}

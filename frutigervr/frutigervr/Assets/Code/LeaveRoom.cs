using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LeaveRoom : MonoBehaviour
{
    public string HandTag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == HandTag)
        {
            if (PhotonNetwork.InRoom)
                PhotonNetwork.LeaveRoom();
        }
    }
}
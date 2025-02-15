using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class JoinRoomTrigger : MonoBehaviourPunCallbacks
{
    public float playersPerRoom = 10f;
    public bool pressed;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            if (PhotonNetwork.IsConnected)
            {
                if (!PhotonNetwork.InRoom)
                {
                    PhotonNetwork.LeaveRoom();
                    PhotonNetwork.JoinRandomRoom();
                }
                else if (PhotonNetwork.CurrentRoom.PlayerCount < playersPerRoom)
                {
                    PhotonNetwork.JoinRoom(PhotonNetwork.CurrentRoom.Name);
                }
            }
        }
    }

    public override void OnJoinedRoom()
    {
        // Room joined successfully
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string roomName = GenerateRandomRoomName();
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = (byte)playersPerRoom };
        PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // Failed to create room
    }

    private string GenerateRandomRoomName()
    {
        const string characters = "0123456789";
        int roomNameLength = 5; // Adjust to your liking
        string roomName = string.Empty;

        for (int i = 0; i < roomNameLength; i++)
        {
            roomName += characters[Random.Range(0, characters.Length)];
        }

        return roomName;
    }
}
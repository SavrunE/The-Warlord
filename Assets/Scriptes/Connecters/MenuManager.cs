using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField room;
    [SerializeField] private PlayerProfile playerProfile;

    public void CreateRoom()
    {
        Save();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(login.text, roomOptions);
    }

    public void JoinRoom()
    {
        Save();
        PhotonNetwork.JoinRoom(room.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    private void Save()
    {
        playerProfile.ChangeData(login.text);
    }
}

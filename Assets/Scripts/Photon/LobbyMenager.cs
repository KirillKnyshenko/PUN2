using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LobbyMenager : MonoBehaviourPunCallbacks
{
    public static LobbyMenager instance;
    public TextMeshProUGUI LogText;

    [SerializeField] private Button _createRoom;
    [SerializeField] private Button _joinRandomRoom;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(0, 99999);
        Log("Player's name is set to " + PhotonNetwork.NickName);
        
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to Master");
        _createRoom.interactable = true;
        _joinRandomRoom.interactable = true;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { IsOpen = true, IsVisible = true, MaxPlayers = 2 });
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room");
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Log("There's no free rooms...");
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    
    private void Log(string text)
    {
        Debug.Log(text);
        LogText.text += "\n";
        LogText.text += text;
    }
}

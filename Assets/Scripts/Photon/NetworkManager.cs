using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerPrefab;
    private void Start()
    {
        var pos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        PhotonNetwork.Instantiate(_playerPrefab.name, pos, Quaternion.identity);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} joined the room ", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left the room ", otherPlayer.NickName);
    }
}

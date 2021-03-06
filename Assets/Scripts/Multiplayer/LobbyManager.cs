using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text logText;


    private void Start()
    {
        PhotonNetwork.NickName = "Gay" + Random.Range(0, 100);
        Log("Your nickname: " + PhotonNetwork.NickName);
        PhotonNetwork.GameVersion = "Sweety";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        Log("Connect to Master.Have fun");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 4 }) ;
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        Log("Joined in room");
        PhotonNetwork.LoadLevel("SampleScene");
    }


    private void Log(string message)
    {
        logText.text +="\n"+ message;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SceneNetworking : MonoBehaviourPunCallbacks
{
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player "+newPlayer.NickName+" entered in room");
    }
}

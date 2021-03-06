using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkObjectSpawner : MonoBehaviour
{
    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("Player",Vector3.zero,Quaternion.identity);
    }


}

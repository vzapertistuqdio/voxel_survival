using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    private Vector3 offset;
    private float camSpeed = 7;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position+offset, camSpeed*Time.deltaTime);
    }
}

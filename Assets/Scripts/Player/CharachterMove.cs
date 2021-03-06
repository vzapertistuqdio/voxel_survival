using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharachterMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float rotateSpeed = 0.1f;

    private Rigidbody rgb;
    private AnimationController animController;

    private Vector3 moveVector;

    private PhotonView photonView;
    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        animController = GetComponent<AnimationController>();
        photonView = GetComponent<PhotonView>();
    }

  
    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;

        float deltaX = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical")*speed * Time.deltaTime;


        moveVector = Vector3.zero;
        moveVector.x = deltaX * speed;
        moveVector.z = deltaY * speed;

        if (moveVector.z != 0 || moveVector.x != 0)
        {
            animController.SetMoveState(true);
        }
        else animController.SetMoveState(false);

        if (Vector3.Angle(transform.forward, moveVector) > 1)
        {
            Vector3 moveDirection = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        rgb.velocity=moveVector * Time.deltaTime;
    }

}

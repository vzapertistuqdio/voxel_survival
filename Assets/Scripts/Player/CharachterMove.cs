using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharachterMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float rotateSpeed = 0.05f;

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

  
    private void Update()
    {
        if (!photonView.IsMine) return;

        float deltaX = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical")*speed * Time.deltaTime;


        moveVector = -(Camera.main.transform.position - transform.position).normalized;
        moveVector.y = 0;
        if (deltaX > 0 || deltaY > 0)
        {
            if (Vector3.Angle(transform.forward, moveVector) > 1)
            {
                Vector3 moveDirection = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed, 0.0f);
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }
        }
        if (deltaY != 0 || deltaX != 0)
            rgb.velocity = transform.forward*deltaY +transform.right*deltaX;

        ChangeAnimation(deltaY,deltaX);
    }

    private void ChangeAnimation(float deltaY,float deltaX)
    {
        animController.ChangeMoveZAnimation(deltaY);
        if (deltaY < 0)
            animController.ChangeMoveXAnimation(-deltaX);
        else
            animController.ChangeMoveXAnimation(deltaX);
    }
}

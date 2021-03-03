using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    private float smoothSpeed;

    private GameObject player;

    private Vector3 offset;

    public Transform target;
    public Vector3 offset1;
    public float sensitivity = 3; // чувствительность мышки
    public float limit = 80; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    private float X, Y;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = player.transform.position - transform.position;

        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset1 = new Vector3(offset1.x, offset1.y, offset1.z);
        transform.position = target.position + offset1;
    }

    private void Update()
    {
       // transform.position = Vector3.MoveTowards(transform.position, player.transform.position - offset,smoothSpeed );

     //   offset1.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        Y += Input.GetAxis("Mouse Y") * sensitivity;
        Y = Mathf.Clamp(Y, -limit, limit);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * offset1 + target.position;
        //  player.transform.rotation
    }

    

   
}

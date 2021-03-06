using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuild : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    private Ray ray;
    private RaycastHit hit;
    private void Start()
    {
        
    }

  
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);


            if (hit.collider.gameObject != null)
            {
               Cube cube= hit.collider.gameObject.GetComponent<Cube>();
                if (cube != null)
                {
                    Vector3 offset = (hit.collider.gameObject.transform.position - transform.position).normalized;
                    Debug.Log(offset);
                    Instantiate(cube, hit.collider.gameObject.transform.position- offset, Quaternion.identity);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    private Camera mainCam;
    private int layerMask;

    void Start()
    {
        layerMask = LayerMask.GetMask("MouseWorld");
        Debug.Log(layerMask);
        mainCam = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 500f, layerMask))
        {
            transform.position = raycastHit.point;
            //Debug.Log("haiii");
        }
    }
}

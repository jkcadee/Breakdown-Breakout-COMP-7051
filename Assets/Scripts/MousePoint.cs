using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    private Camera mainCam;
    private int layerMask;

    void Start()
    {
        // only shoots the ray on the MouseWorld layer
        layerMask = LayerMask.GetMask("MouseWorld");
        mainCam = Camera.main;
    }

    void Update()
    {
        // used this video as reference:
        // https://www.youtube.com/watch?v=0jTPKz3ga4w
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 500f, layerMask))
        {
            // moves THIS OBJECT to the point of the mouse
            transform.position = raycastHit.point;
        }
    }
}

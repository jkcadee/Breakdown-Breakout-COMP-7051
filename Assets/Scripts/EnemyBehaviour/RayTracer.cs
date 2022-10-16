using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTracer : MonoBehaviour
{


    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawLine(this.transform.position, this.transform.forward * 50f, Color.red, 2, true);
    }
}

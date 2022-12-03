using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtVolumeFX : MonoBehaviour
{
    public float fixSpeed = 0.02f;
    GameObject ufo;

    public void ActivateHit()
    {
        transform.localPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
        if(transform.localPosition.x < 3)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + fixSpeed, 0, 0);
        }
        if(!ufo)
        {
            ufo = GameObject.Find("UFO(Clone)");
            ufo.GetComponent<PlayerDamageable>().hvf = GetComponent<HurtVolumeFX>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class position : MonoBehaviour
{
    public Transform player;

    void Awake(){
        transform.SetParent(player);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    void Update(){
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
        
}

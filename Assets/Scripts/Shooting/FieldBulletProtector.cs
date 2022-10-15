using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBulletProtector : MonoBehaviour
{
    public string shooterTag;
    public GameObject bullet;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == shooterTag)
        {
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>());
        }
    }
}

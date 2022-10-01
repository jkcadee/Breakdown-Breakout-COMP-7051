using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;

    // if the bullet hits something other than the shooter, delete self
    // this will need to be updated later
    private void OnCollisionEnter(Collision other)
    {
        if(transform.parent != other.transform && other.gameObject.tag != "Bullet")
            Destroy(gameObject);
    }

    public void SetShooter(GameObject s)
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartMovement(float x, float z)
    {
        Vector3 v3 = new Vector3(x, 0, z);
        rb.AddForce(v3, ForceMode.VelocityChange);
    }
}

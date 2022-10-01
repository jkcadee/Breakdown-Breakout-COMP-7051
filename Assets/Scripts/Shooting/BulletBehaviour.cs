using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;
    GameObject shooter;

    // if the bullet hits something other than the shooter, delete self
    // this will need to be updated later
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Bullet" && shooter.tag != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            target?.GetHit(1f);
            Destroy(gameObject);
            Debug.Log(other.gameObject.name);
        }
    }

    public void SetShooter(GameObject s)
    {
        rb = GetComponent<Rigidbody>();
        shooter = s;
    }

    public void StartMovement(Vector3 v3)
    {
        rb.AddForce(v3, ForceMode.VelocityChange);
    }
}

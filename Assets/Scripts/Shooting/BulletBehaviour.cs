using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;
    GameObject shooter;
    public float damageDealt = 1f;
    public float shootCooldown = 0.3f;
    public float bulletSpeed = 40f;

    // if the bullet hits something other than the shooter, delete self
    // this will need to be updated later
    private void OnCollisionEnter(Collision other)
    {
        if(shooter.tag != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            target?.GetHit(damageDealt, gameObject);
            Destroy(gameObject);
        }
    }

    public GameObject GetShooter()
    {
        return shooter;
    }

    public void SetShooter(GameObject s)
    {
        rb = GetComponent<Rigidbody>();
        shooter = s;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public Vector3 GetVelocity()
    {
        return rb.velocity;
    }

    public void StartMovement(Vector3 v3)
    {
        rb.AddForce(v3, ForceMode.VelocityChange);
    }
}

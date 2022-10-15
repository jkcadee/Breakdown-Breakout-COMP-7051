using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : BulletBehaviour
{
    int layerMask;
    bool stoppedMotion = false;
    bool destroyState = false;
    static GameObject beam;

    void OnCollisionEnter(Collision other)
    {
        if (GetShooter().tag != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            target?.GetHit(damageDealt, gameObject);
            destroyState = true;
        }
    }

    private void Start()
    {
        Destroy(beam);
        beam = gameObject;
        layerMask = LayerMask.GetMask("Default");

        Vector3 pointDir = transform.position + GetIntendedVelocity();
        pointDir.y = transform.position.y;
        transform.LookAt(pointDir);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 500f, layerMask))
        {
            transform.position = transform.position + (hit.point - transform.position) / 2;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, hit.distance / transform.localScale.z + 0.5f);
        }
    }

    private void FixedUpdate()
    {
        if(!stoppedMotion && GetVelocity() != Vector3.zero)
        {
            stoppedMotion = true;
            GetRigidbody().velocity = Vector3.zero;
        }
        if(destroyState) Destroy(gameObject);
    }
}

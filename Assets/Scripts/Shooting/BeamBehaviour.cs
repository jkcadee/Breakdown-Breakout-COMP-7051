using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : BulletBehaviour
{
    public LayerMask layerMask;
    bool stoppedMotion = false;
    bool destroyState = false;
    static Dictionary<GameObject, GameObject> beams = new();

    void OnCollisionEnter(Collision other)
    {
        if (GetShooterTag() != other.gameObject.tag)
        {
            // hit the target and destroy self (self explanatory p much)
            Damageable target = other.gameObject.GetComponent<Damageable>();
            target?.GetHit(damageDealt, gameObject);
            destroyState = true;
        }
    }

    void ReplaceBeam()
    {
        GameObject beam;

        if (beams.TryGetValue(GetShooter(), out beam))
        {
            Destroy(beam);
            beams[GetShooter()] = gameObject;
        } 
        else
        {
            beams.Add(GetShooter(), gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();

        // deletes the old beam
        ReplaceBeam();
        layerMask = ~layerMask;

        // points the beam in the right direction
        Vector3 pointDir = transform.position + GetIntendedVelocity();
        pointDir.y = transform.position.y;
        transform.LookAt(pointDir);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 500f, layerMask))
        {
            // moves the beam into the middle of [its origin] and [the point of contact]
            transform.position = transform.position + (hit.point - transform.position) / 2;
            // makes the beam as long as the distance between the two points
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, hit.distance + 0.5f);
        }
    }

    private void FixedUpdate()
    {
        // motion needs to be stopped because the velocity needs to be a non-zero value,
        // or else the beam won't be able to get a direction
        if(!stoppedMotion && GetVelocity() != Vector3.zero)
        {
            stoppedMotion = true;
            GetRigidbody().velocity = Vector3.zero;
        }
        // only destroys the beam on a fixed update (to maintain the image of a true, solid "beam" rather than like. a machine gun lol)
        if(destroyState) Destroy(gameObject);
        destroyState = true;
    }
}

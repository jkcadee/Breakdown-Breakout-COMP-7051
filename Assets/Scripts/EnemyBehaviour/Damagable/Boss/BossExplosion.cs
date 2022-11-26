using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExplosion : BulletBehaviour
{
    public GameObject explosionPrefab;
    public float distanceBeforeExplosion = 25f;
    Vector3 startPosition;
    public GameObject bulletPrefab;
    public float splinterSpread = 5f;
    bool activated = false;

    // makes a "splinter" shot at a given modified angle
    void SplinterShot(float angle, GameObject shooter, Vector3 velocity)
    {
        // creates the bullet
        GameObject bullet = Instantiate(bulletPrefab, transform);
        bullet.transform.SetParent(null);
        bullet.transform.localScale = bulletPrefab.transform.localScale; // bullets are 0.6 scale so this has to be done or the splinters are smaller lol

        // disables collision for the shooter
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), shooter.GetComponent<Collider>());

        // sets shooter, damage, and velocity for the child bullet
        BulletBehaviour bh = bullet.GetComponent<BulletBehaviour>();
        bh.SetShooter(shooter);
        bh.damageDealt = damageDealt; // child bullets will always have the same damage as the parent
        bh.StartMovement((Quaternion.Euler(0, angle, 0) * velocity).normalized * bh.bulletSpeed);
    }

    // creates the splinter shots for the bullet
    void Activate()
    {
        activated = true;
        GameObject shooter = GetShooter();
        Vector3 velocity = GetVelocity();

        SplinterShot(-splinterSpread, shooter, velocity);
        SplinterShot(splinterSpread, shooter, velocity);
    }

    private void FixedUpdate()
    {
        // this has to be done because the velocity is zero on start, for some reason :(
        // waits for the velocity to be non-zero, and then activates and makes splinter shots
        if (!activated && GetVelocity() != Vector3.zero) Activate();
                // destroys the bullet once it's travelled past a certain distance
        if (Vector3.Distance(transform.position, startPosition) > distanceBeforeExplosion) 
            Explode();
    }

    void Explode()
    {
        // create an explosion
        GameObject explosion = Instantiate(explosionPrefab, transform);
        explosion.transform.parent = null;
        explosion.transform.position = gameObject.transform.position;
        ExplosionBehaviour eb = explosion.GetComponent<ExplosionBehaviour>();
        
        // give the explosion the info it needs
        eb.SetShooter(GetShooter());
        eb.SetDamageDealt(damageDealt);
        
        // destroy the bullet
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(GetShooterTag() != other.gameObject.tag)
        {
            Explode();
        }
    }

    protected override void Start()
    {
        base.Start();
        startPosition = transform.position;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBounce : BulletBehaviour
{
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
    }

        public int bounces = 2;
    public float bounceDamageModifier = 1.5f;

    private void OnCollisionEnter(Collision other)
    {
        if (GetShooterTag() != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            if(target != null) // if the target is damageable, the bullet will not bounce
            {
                target?.GetHit(damageDealt, gameObject);
                Destroy(gameObject);
            } 
            else if(bounces < 1)
            {
                Destroy(gameObject);
            }

            // if it bounces, decrement the bounces and modify the damage dealt by the bounce damage modifier
            // i.e. every time the bullet bounces, it will do more/less damage
            bounces -= 1;
            damageDealt *= bounceDamageModifier;
        }
    }
}

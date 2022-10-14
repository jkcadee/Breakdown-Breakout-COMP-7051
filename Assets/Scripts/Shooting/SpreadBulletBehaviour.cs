using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBulletBehaviour : BulletBehaviour
{
    public GameObject bulletPrefab;
    bool activated = false;

    void SplinterShot(float angle, GameObject shooter, Vector3 velocity)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform);
        bullet.transform.SetParent(null);
        bullet.transform.localScale = bulletPrefab.transform.localScale;
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), shooter.GetComponent<Collider>());
        BulletBehaviour bh = bullet.GetComponent<BulletBehaviour>();
        bh.SetShooter(shooter);
        bh.damageDealt = damageDealt;
        bh.StartMovement((Quaternion.Euler(0, angle, 0) * velocity).normalized * bh.bulletSpeed);
    }

    void Activate()
    {

        activated = true;
        GameObject shooter = GetShooter();
        Vector3 velocity = GetVelocity();

        SplinterShot(-10f, shooter, velocity);
        SplinterShot(10f, shooter, velocity);
    }

    private void FixedUpdate()
    {
        if (!activated && GetVelocity() != Vector3.zero) Activate();
    }
}

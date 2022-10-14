using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 25f;
    public GameObject shooter;

    public void ShootAtTarget(Vector3 target)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform);
        bullet.transform.SetParent(null);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), shooter.GetComponent<Collider>());
        BulletBehaviour bh = bullet.GetComponent<BulletBehaviour>();
        bh.SetShooter(shooter);
        bh.StartMovement((target - transform.position).normalized * bulletSpeed);
    }

}

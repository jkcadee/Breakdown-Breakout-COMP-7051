using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;
    public AudioController aCtrl;

    public void ShootAtTarget(Vector3 target)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform);
        bullet.transform.SetParent(null);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), shooter.GetComponent<Collider>());
        BulletBehaviour bh = bullet.GetComponent<BulletBehaviour>();
        bh.SetShooter(shooter);
        bh.StartMovement((target - transform.position).normalized * bh.bulletSpeed);
        aCtrl.PlayShoot();
    }

    public void SetBulletPrefab(GameObject bulletType)
    {
        bulletPrefab = bulletType;
    }
}

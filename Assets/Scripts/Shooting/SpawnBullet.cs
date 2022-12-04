using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;
    ParticleSystem ps;

    private void MakeFlash(Vector3 target)
    {
        GameObject flash = Instantiate(LevelManager.Instance.muzzleFlashPrefab, transform.position, Quaternion.identity);
        ps = flash.GetComponent<ParticleSystem>();
        ps.transform.LookAt(target);
        Destroy(ps.gameObject, 1);
    }

    public void ShootAtTarget(Vector3 target)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform);
        bullet.transform.SetParent(null);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), shooter.GetComponent<Collider>());
        BulletBehaviour bh = bullet.GetComponent<BulletBehaviour>();
        bh.SetShooter(shooter);
        bh.StartMovement((target - transform.position).normalized * bh.bulletSpeed);
        AudioController.PlayShoot();
        MakeFlash(target);
    }

    public void SetBulletPrefab(GameObject bulletType)
    {
        bulletPrefab = bulletType;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            BulletBehaviour bh = bullet.GetComponent<BulletBehaviour>();
            bh.SetShooter(gameObject);
            bh.StartMovement(3, 3);
        }
    }

}

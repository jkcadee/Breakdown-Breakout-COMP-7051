using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShooting : MonoBehaviour
{
    private TutorialBullet tb;
    [SerializeField] private float weaponCooldown;
        private float _fireTimer;
    public  Transform targetDummy;
    // Start is called before the first frame update
    void Start()
    {
        tb = GetComponent<TutorialBullet>();
        weaponCooldown = tb.bulletPrefab.GetComponent<BulletBehaviour>().shootCooldown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
                if (Time.time > _fireTimer)
                {
                    _fireTimer = Time.time + weaponCooldown;
                    Shoot();
                }
    }


        void Shoot()
    {   
        
        tb.ShootAtTarget(targetDummy.position);

    } 
}

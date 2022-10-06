using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    // Start is called before the first frame update

    public void Fire(){
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.up * fireForce, ForceMode.Impulse);
    }
}

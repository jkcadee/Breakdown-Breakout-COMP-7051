using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private SpawnBullet sb;
    public GameObject target;

    void Start()
    {
        sb = GetComponent<SpawnBullet>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            sb.ShootAtTarget(target.transform.position);
        }
    }
}

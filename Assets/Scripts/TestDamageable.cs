using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageable : Damageable
{
    public override void GetHit(float damage, GameObject collisionBullet) 
    {
        Debug.Log("Ough!!!! " + damage + " damage taken!!!!");
        Debug.Log("Hit by " + collisionBullet);
    }
}

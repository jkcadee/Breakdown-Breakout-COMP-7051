using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBulletBehaviour : BulletBehaviour
{

    // if the bullet hits something other than the shooter, delete self
    // this will need to be updated later
    private void OnCollisionEnter(Collision other)
    {
        if(GetShooter().tag != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            target?.GetHit(damageDealt, gameObject);
            Destroy(gameObject);
        }
    }
}

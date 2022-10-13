using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBulletBehaviour : BulletBehaviour
{
    public int bounces = 1;

    private void OnCollisionEnter(Collision other)
    {
        if (GetShooter().tag != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            if(target != null)
            {
                target?.GetHit(damageDealt, gameObject);
                Destroy(gameObject);
            } 
            else if(bounces < 1)
            {
                Destroy(gameObject);
            }

            bounces -= 1;
        }
    }
}

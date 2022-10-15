using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBulletBehaviour : BulletBehaviour
{
    public int bounces = 2;
    public float bounceDamageModifier = 1.5f;

    private void OnCollisionEnter(Collision other)
    {
        if (GetShooter().tag != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            if(target != null) // if the target is damageable, the bullet will not bounce
            {
                target?.GetHit(damageDealt, gameObject);
                Destroy(gameObject);
            } 
            else if(bounces < 1)
            {
                Destroy(gameObject);
            }

            // if it bounces, decrement the bounces and modify the damage dealt by the bounce damage modifier
            // i.e. every time the bullet bounces, it will do more/less damage
            bounces -= 1;
            damageDealt *= bounceDamageModifier;
        }
    }
}

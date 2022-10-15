using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float explosionRate = 1.2f;
    public float implosionRate = 1.3f;
    public float explosionMaxSize = 5f;
    bool imploding = false;
    GameObject shooter;
    float damageDealt;

    public void SetShooter(GameObject s)
    {
        shooter = s;
    }

    // used so that you set the damage values via the exploding bullet itself
    public void SetDamageDealt(float dd)
    {
        damageDealt = dd;
    }

    // rigidbody is required for this to work btw (like the enemy must have a rigidbody)
    private void OnTriggerEnter(Collider other)
    {
        if (shooter.tag != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            target?.GetHit(damageDealt, gameObject);
        }
    }

    void FixedUpdate()
    {
        // explosion goes out
        if (!imploding)
        {
            transform.localScale *= explosionRate;
            if (transform.localScale.x > explosionMaxSize) imploding = true;
        }
        else // and then in
        {
            transform.localScale /= implosionRate;
            if (transform.localScale.x < 0.05f) Destroy(gameObject); // and then destroys itself once it's small enough
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBulletBehaviour : BulletBehaviour
{
    public GameObject explosionPrefab;
    public float distanceBeforeExplosion = 17f;
    Vector3 startPosition;

    void Explode()
    {
        // create an explosion
        GameObject explosion = Instantiate(explosionPrefab, transform);
        explosion.transform.parent = null;
        explosion.transform.position = gameObject.transform.position;
        ExplosionBehaviour eb = explosion.GetComponent<ExplosionBehaviour>();
        
        // give the explosion the info it needs
        eb.SetShooter(GetShooter());
        eb.SetDamageDealt(damageDealt);
        
        // destroy the bullet
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(GetShooterTag() != other.gameObject.tag)
        {
            Explode();
        }
    }

    protected override void Start()
    {
        base.Start();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // destroys the bullet once it's travelled past a certain distance
        if (Vector3.Distance(transform.position, startPosition) > distanceBeforeExplosion) 
            Explode();
    }
}

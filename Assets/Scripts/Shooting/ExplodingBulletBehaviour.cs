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
        GameObject explosion = Instantiate(explosionPrefab, transform);
        explosion.transform.parent = null;
        explosion.transform.position = gameObject.transform.position;
        ExplosionBehaviour eb = explosion.GetComponent<ExplosionBehaviour>();
        eb.SetShooter(GetShooter());
        eb.SetDamageDealt(damageDealt);
        Destroy(gameObject);
    }

    // if the bullet hits something other than the shooter, delete self
    // this will need to be updated later
    private void OnCollisionEnter(Collision other)
    {
        if(GetShooter().tag != other.gameObject.tag)
        {
            Explode();
        }
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, startPosition) > distanceBeforeExplosion) 
            Explode();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;
    GameObject shooter;
    string shooterTag;
    Vector3 intendedVelocity;
    public float damageDealt = 1f;
    public float shootCooldown = 0.3f;
    public float bulletSpeed = 40f;
    public float spreadAngle = 0;
    public int ammo = 8;
    public GameObject bulletATFieldPrefab;
    float selfDestruct = 0;
    public float timeToSelfDestruct = 5f;

    protected virtual void Start()
    {
        GameObject bulletATField = Instantiate(bulletATFieldPrefab, transform);
        FieldBulletProtector fbp = bulletATField.GetComponent<FieldBulletProtector>();
        fbp.shooterTag = shooter.tag;
        fbp.bullet = gameObject;

        shooterTag = shooter.tag;
    }

    // if the bullet hits something other than the shooter, delete self
    // this will need to be updated later
    private void OnCollisionEnter(Collision other)
    {
        if(shooterTag != other.gameObject.tag)
        {
            Damageable target = other.gameObject.GetComponent<Damageable>();
            target?.GetHit(damageDealt, gameObject);
            Destroy(gameObject);
        }
    }

    public string GetShooterTag()
    {
        return shooter.tag;
    }

    public GameObject GetShooter()
    {
        return shooter;
    }

    public void SetShooter(GameObject s)
    {
        rb = GetComponent<Rigidbody>();
        shooter = s;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public Vector3 GetVelocity()
    {
        return rb.velocity;
    }

    public float GetDamageDealt()
    {
        return damageDealt;
    }

    public Vector3 GetIntendedVelocity()
    {
        return intendedVelocity;
    }

    public void StartMovement(Vector3 v3)
    {
        Vector3 adjustedAngleMovement = Quaternion.Euler(0, Random.Range(-spreadAngle, spreadAngle), 0) * v3;
        intendedVelocity = adjustedAngleMovement;
        rb.AddForce(adjustedAngleMovement, ForceMode.VelocityChange);
    }

    public void Update()
    {
        selfDestruct += Time.deltaTime;

        if(!shooter || selfDestruct > timeToSelfDestruct)
        {
            Destroy(gameObject);
        }
    }
}

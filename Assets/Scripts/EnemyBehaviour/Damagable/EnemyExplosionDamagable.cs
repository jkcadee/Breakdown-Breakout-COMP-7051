using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionDamagable : Damageable
{

    public EnemyControls enemy;
    public EnemyAI ai;
    public EnemyShield shield;
    private Collision collision;
    public AudioSource hit;
    public override void GetHit(float damage, GameObject other)
    {
        Debug.Log(shield.hasShield);
        if (shield.hasShield)
        {
            Debug.Log("Hit Shield!!!");
            Debug.Log("IS IT THE CORRECT BULLET???" + shield.correctBullet);
            if (other.name == "Explosion(Clone)")
            {
                enemy.shield -= 5f;
            }
            else
            {
                enemy.shield -= 1f;
            }
        }
        else
        {
            Debug.Log("Didn't Hit Shield!!!");
            enemy.health -= damage;
        }

        AudioController.PlaySFX(hit);
        ai.angerTimer = 4f;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyExplosionDamagable : Damageable
{

    public EnemyControls enemy;
    public EnemyAI ai;
    public EnemyShield shield;

    public ExplosionBehaviour bb;

    // private Collision collision;
    // public AudioSource hit;
    public override void GetHit(float damage, GameObject other)
    {
        Debug.Log(shield.hasShield);
        if (shield.hasShield)
        {
            Debug.Log("Hit Shield!!!");
            Debug.Log("IS IT THE CORRECT BULLET???" + shield.correctBullet);
            if (other.name == "Explosion(Clone)")
            {
                enemy.shield -= 2.8f;
            }
            else if (other.name == "Beam(Clone)")
            {
                enemy.shield -= 0.06f;
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

        ai.angerTimer = 4f;
        AudioController.PlayHit();

        if (enemy.shield != shield.maxShield && enemy.shield > 0)
        {
            enemy.healthBarImage.color = new Color(255f, 100f / 255f, 0f);

        } else
        {
            enemy.healthBarImage.color = new Color(255f , 0, 0);

        }
    }
}

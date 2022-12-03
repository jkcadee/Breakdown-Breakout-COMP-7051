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
        // check if shield is hit by the correct weapon types
        if (shield.hasShield)
        {

            if (other.name == "Explosion(Clone)")
            {
                enemy.shield -= damage * 2;
                AudioController.PlayCorrect();
            }
            else if (other.name == "Beam(Clone)")
            {
                enemy.shield -= 0.03f;
                AudioController.PlayIncorrect();
            }
            else
            {
                enemy.shield -= 1f;
                AudioController.PlayIncorrect();
            }
        }
        else
        {

            enemy.health -= damage;
        }

        ai.angerTimer = 4f;
        AudioController.PlayHit();
        // Modify health bar correct depending on if shield is broken
        if (enemy.shield != shield.maxShield && enemy.shield > 0)
        {
            enemy.healthBarImage.color = new Color(255f, 100f / 255f, 0f);

        } else
        {
            enemy.healthBarImage.color = new Color(255f , 0, 0);

        }
    }
}

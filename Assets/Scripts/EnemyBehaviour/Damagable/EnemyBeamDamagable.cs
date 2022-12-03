using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeamDamagable : Damageable
{

    public EnemyControls enemy;
    public EnemyAI ai;
    public EnemyShield shield;
    // private Collision collision;
    // public AudioSource hit;
    public override void GetHit(float damage, GameObject other)
    {
        // check if shield is hit by the correct weapon types
        if (shield.hasShield)
        {

            if (other.name == "Beam(Clone)")
            {
                enemy.shield -= damage * 3;
                AudioController.PlayCorrect();
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

        AudioController.PlayHit();
        ai.angerTimer = 4f;

        // Modify health bar correct depending on if shield is broken
        if (enemy.shield != shield.maxShield && enemy.shield > 0)
        {
            enemy.healthBarImage.color = new Color(215 / 255f, 90 / 255f, 165 / 255f);

        } else
        {
            enemy.healthBarImage.color = new Color(255f , 0, 0);

        }
    }
}

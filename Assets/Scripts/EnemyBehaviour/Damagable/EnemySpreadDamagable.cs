using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpreadDamagable : Damageable
{
    public EnemyControls enemy;
    public EnemyAI ai;
    public EnemyShield shield;
    // private Collision collision;
    // public AudioSource hit;
    public override void GetHit(float damage, GameObject other)
    {
        Debug.Log(shield.hasShield);
        if (shield.hasShield)
        {
            // check if shield is hit by the correct weapon types
            if ((other.name == "SpreadBullet(Clone)" || other.name == "SpreadBulletChild(Clone)") && this.name == "TutorialShield")
            {
                enemy.shield -= 15f;
                AudioController.PlayCorrect();
            }
            else if (other.name == "SpreadBullet(Clone)") {
                enemy.shield -= damage * 3;
                AudioController.PlayCorrect();
            }

            else if (other.name == "SpreadBulletChild(Clone)") 
            {
                enemy.shield -= damage * 3;
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

        AudioController.PlayHit();
        ai.angerTimer = 4f;
        // Modify health bar correct depending on if shield is broken
        if (enemy.shield != shield.maxShield && enemy.shield > 0)
        {
            enemy.healthBarImage.color = new Color(0f, 175f / 255f, 255f);

        } else
        {
            enemy.healthBarImage.color = new Color(255f, 0f, 0f);

        }
    }
}

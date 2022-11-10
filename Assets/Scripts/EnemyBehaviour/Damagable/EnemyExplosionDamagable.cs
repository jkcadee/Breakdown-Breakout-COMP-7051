using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyExplosionDamagable : Damageable
{

    public EnemyControls enemy;
    public EnemyAI ai;
    public EnemyShield shield;
    private Collision collision;
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

        AudioController.PlayHit();
        ai.angerTimer = 4f;


        if (enemy.shield != enemy.maxShield && enemy.shield > 0)
        {
            enemy.healthBarImage.color = new Color(255f, 100f / 255f, 0f);

        } else
        {
            enemy.healthBarImage.color = new Color(255f , 0, 0);

        }
    }
}

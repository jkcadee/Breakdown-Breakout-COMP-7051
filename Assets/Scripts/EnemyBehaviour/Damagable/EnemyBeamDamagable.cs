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
        Debug.Log(shield.hasShield);
        if (shield.hasShield)
        {
            Debug.Log("Hit Shield!!!");
            Debug.Log("IS IT THE CORRECT BULLET???" + shield.correctBullet);
            if (other.name == "Beam(Clone)")
            {
                enemy.shield -= 0.12f;
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


        if (enemy.shield != shield.maxShield && enemy.shield > 0)
        {
            enemy.healthBarImage.color = new Color(215 / 255f, 90 / 255f, 165 / 255f);

        } else
        {
            enemy.healthBarImage.color = new Color(255f , 0, 0);

        }
    }
}
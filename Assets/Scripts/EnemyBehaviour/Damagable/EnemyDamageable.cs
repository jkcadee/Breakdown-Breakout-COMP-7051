using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : Damageable
{
    public EnemyControls enemy;
    public EnemyAI ai;
    public AudioSource hit;

    public override void GetHit(float damage, GameObject other)
    {

        enemy.health -= damage;

        ai.angerTimer = 4f;

        AudioController.PlaySFX(hit);

    }

}

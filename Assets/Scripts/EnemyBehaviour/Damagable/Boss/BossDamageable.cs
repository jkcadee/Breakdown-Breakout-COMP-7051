using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageable : Damageable
{
    public BossController boss;
    
    public EnemyAI ai;

    public override void GetHit(float damage, GameObject other)
    {

        boss.health -= damage;

        ai.angerTimer = 4f;

        AudioController.PlayHit();

    }

}

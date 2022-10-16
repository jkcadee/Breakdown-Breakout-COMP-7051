using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : Damageable
{
    public EnemyAI enemy;
    public override void GetHit(float damage, GameObject other) {
        enemy.health -= damage;
        
    }
    

}

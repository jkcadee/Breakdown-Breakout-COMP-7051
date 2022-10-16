using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    public PlayerControls player;
    public override void GetHit(float damage, GameObject other)
    {
        player.health -= damage;
        player.UpdateHealth();
    }
}

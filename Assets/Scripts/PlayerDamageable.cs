using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    PlayerControls player;

    private void Start()
    {
        player = GetComponent<PlayerControls>();
    }

    public override void GetHit(float damage, GameObject other)
    {
        player.health -= damage;
        player.UpdateHealth();
    }
}

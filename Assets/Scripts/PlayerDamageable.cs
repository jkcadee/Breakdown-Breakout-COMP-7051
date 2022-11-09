using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    PlayerControls player;
    //public AudioController aCtrl;
    public AudioSource hit;

    private void Start()
    {
        player = GetComponent<PlayerControls>();
    }

    public override void GetHit(float damage, GameObject other)
    {
        player.health -= damage;
        player.UpdateHealth();
        //aCtrl.PlayHit();
        AudioController.PlaySFX(hit);
    }
}

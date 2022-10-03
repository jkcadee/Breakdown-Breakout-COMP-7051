using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageable : Damageable
{
    public override void GetHit(float damage) 
    {
        Debug.Log("Ough!!!! " + damage + " damage taken!!!!");
    }
}

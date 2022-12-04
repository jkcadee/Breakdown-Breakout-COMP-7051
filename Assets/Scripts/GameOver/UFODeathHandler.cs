using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spawns the death screen when UFO dies (DieNow is called by another script)
public class UFODeathHandler : MonoBehaviour
{
    public GameObject deathScreen;
    public void DieNow()
    {
        Instantiate(deathScreen);
    }
}

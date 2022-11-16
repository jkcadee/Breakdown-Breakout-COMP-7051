using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFODeathHandler : MonoBehaviour
{
    public GameObject deathScreen;
    public void DieNow()
    {
        Instantiate(deathScreen);
    }
}

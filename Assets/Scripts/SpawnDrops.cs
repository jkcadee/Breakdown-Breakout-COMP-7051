using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrops : MonoBehaviour
{
    // try two per weapon spawn point
    private int maxNumOfSpawnedWeapons = 4;
    private int spawnedWeaponCounter;

    // eventually we will have a list of different weapons and be taking randomly from that list
    public GameObject weaponSpawn;

    private void spawnNewWeapon()
    {
        Debug.Log("Spawn new wep");
        Instantiate(weaponSpawn, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        spawnedWeaponCounter = GameObject.FindGameObjectsWithTag("Weapon").Length;
        if (spawnedWeaponCounter < maxNumOfSpawnedWeapons)
        {
            spawnNewWeapon();
            spawnedWeaponCounter++;
        }
    }
}

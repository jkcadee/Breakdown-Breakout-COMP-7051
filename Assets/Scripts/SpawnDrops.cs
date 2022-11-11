using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrops : MonoBehaviour
{
    // try two per weapon spawn point
    private int maxNumOfSpawnedWeapons = 4;
    private int spawnedWeaponCounter;

    // timer for when drops will spawn
    private float spawnWaitTime = 4.0f;
    private float timer = 0.0f;

    // eventually we will have a list of different weapons and be taking randomly from that list
    public GameObject weaponSpawn;

    private void spawnNewWeapon()
    {
        Vector3 pos;

        float maxSpawnPosX = transform.position.x;
        //float maxSpawnPosY = transform.position.y; // we will probably be using this value
        float maxSpawnPosZ = transform.position.z;

        // this part of the code randomly spawns in a new item at a new point around the pickup spots
        if (maxSpawnPosX < 0 && maxSpawnPosZ < 0)
        {
            pos = new Vector3(Random.Range(maxSpawnPosX + 5, maxSpawnPosX + 1), 1f, Random.Range(maxSpawnPosZ + 5, maxSpawnPosZ + 1));
        } else if (maxSpawnPosX > 0 && maxSpawnPosZ > 0)
        {
            pos = new Vector3(Random.Range(maxSpawnPosX - 5, maxSpawnPosX - 1), 1f, Random.Range(maxSpawnPosZ - 5, maxSpawnPosZ - 1));
        } else
        {
            pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        Instantiate(weaponSpawn, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        spawnedWeaponCounter = GameObject.FindGameObjectsWithTag("Weapon").Length;
        if (spawnedWeaponCounter < maxNumOfSpawnedWeapons && timer > spawnWaitTime)
        {
            spawnNewWeapon();
            spawnedWeaponCounter++;
            timer = 0.0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrops : MonoBehaviour
{
    // try two per weapon spawn point
    private int maxNumOfSpawnedWeapons = 2;
    private int spawnedWeaponCounter;

    // timer for when drops will spawn
    private float spawnWaitTime = 4.0f; //4.0f
    private float timer = 0.0f;

    // eventually we will have a list of different weapons and be taking randomly from that list
    public GameObject weaponSpawn;

    public List<GameObject> spawnedWeapons = new();

    private void spawnNewWeapon()
    {
        Vector3 pos;

        float maxSpawnPosX = transform.position.x;
        float maxSpawnPosZ = transform.position.z;
        bool spawned = false;

        while (!spawned)
        {
            // this part of the code randomly spawns in a new item at a new point around the pickup spots
            if (maxSpawnPosX < 0 && maxSpawnPosZ < 0)
            {
                pos = new Vector3(Random.Range(maxSpawnPosX + 5, maxSpawnPosX + 1), 1f, Random.Range(maxSpawnPosZ + 5, maxSpawnPosZ + 1));
            }
            else if (maxSpawnPosX > 0 && maxSpawnPosZ > 0)
            {
                pos = new Vector3(Random.Range(maxSpawnPosX - 5, maxSpawnPosX - 1), 1f, Random.Range(maxSpawnPosZ - 5, maxSpawnPosZ - 1));
            }
            else
            {
                pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }

            Collider[] results = new Collider[1];
            if (Physics.OverlapSphereNonAlloc(pos, 1.0f, results) == 1)
            {
                GameObject newWep = Instantiate(weaponSpawn, pos, Quaternion.identity);
                spawnedWeapons.Add(newWep);
                spawned = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        for (int i = 0; i < maxNumOfSpawnedWeapons; i++)
        {
            if (spawnedWeapons.Count == 0 && timer > spawnWaitTime)
            {
                spawnNewWeapon();
                timer = 0.0f;
                spawnedWeaponCounter++;
            }
            else if (spawnedWeaponCounter != maxNumOfSpawnedWeapons && timer > spawnWaitTime)
            {
                spawnNewWeapon();
                timer = 0.0f;
                spawnedWeaponCounter++;
            }

            if (spawnedWeaponCounter == maxNumOfSpawnedWeapons)
            {
                if (spawnedWeapons[i] == null)
                {
                    spawnedWeapons.RemoveAt(i);
                    timer = 0.0f;
                    spawnedWeaponCounter--;
                }
            }
        }

    }
}

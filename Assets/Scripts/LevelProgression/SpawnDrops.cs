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
    private float topBound;
    private float bottomBound;
    private float leftBound;
    private float rightBound;

    public List<GameObject> spawnedWeapons = new();
    public Vector3 pos;

    private void spawnNewWeapon()
    {
        float spawnerPosX = transform.position.x;
        float spawnerPosZ = transform.position.z;
        float maxSpawnPosX = transform.position.x;
        float maxSpawnPosZ = transform.position.z;
        bool spawned = false;

        while (!spawned)
        {
            // this part of the code randomly spawns in a new item at a new point around the pickup spots

            if ((0 >= spawnerPosX && spawnerPosX > leftBound) && (0 >= spawnerPosZ && maxSpawnPosZ > bottomBound))
            {
                pos = new Vector3(Random.Range(maxSpawnPosX + 5, maxSpawnPosX + 1), 1f, Random.Range(maxSpawnPosZ + 5, maxSpawnPosZ + 1));
            }
            else if ((0 < spawnerPosX && spawnerPosX < rightBound) && (0 < spawnerPosZ && spawnerPosZ < topBound))
            {
                pos = new Vector3(Random.Range(maxSpawnPosX - 5, maxSpawnPosX - 1), 1f, Random.Range(maxSpawnPosZ - 5, maxSpawnPosZ - 1));
            }
            else if ((0 >= spawnerPosX && spawnerPosX > leftBound) && (0 <= spawnerPosZ && spawnerPosZ < topBound))
            {
                pos = new Vector3(Random.Range(maxSpawnPosX + 5, maxSpawnPosX + 1), 1f, Random.Range(maxSpawnPosZ - 5, maxSpawnPosZ - 1));
            }
            else if ((0 < spawnerPosX && spawnerPosX < rightBound) && (0 > spawnerPosZ && maxSpawnPosZ > bottomBound))
            {
                pos = new Vector3(Random.Range(maxSpawnPosX - 5, maxSpawnPosX - 1), 1f, Random.Range(maxSpawnPosZ + 5, maxSpawnPosZ + 1));
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

    void Start()
    {
        topBound = GameObject.Find("North Wall").transform.position.z - 0.5f;
        bottomBound = GameObject.Find("South Wall").transform.position.z + 0.5f;
        leftBound = GameObject.Find("West Wall").transform.position.x + 0.5f;
        rightBound = GameObject.Find("East Wall").transform.position.x - 0.5f;
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

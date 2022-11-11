using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThroughDoors : MonoBehaviour
{
    public LevelManager levelManager;
    public DoorLocks doorLocks;
    public GameObject door;
    public Material material;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            levelManager.LoadLevel();
        }
    }
}

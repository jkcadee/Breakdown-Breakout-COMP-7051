using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThroughDoors : MonoBehaviour
{
    public LevelManager levelManager;
    public DoorLocks doorLocks;
    public GameObject door;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (gameObject.tag == "FinalDoor")
            {
                Level_Timer.PauseTime();
                Debug.Log("Saving Current Time: " + Level_Timer.GetTime());
                ScoreController.sCtrl.SaveScore(Level_Timer.GetTime());
                Level_Timer.ResetTime();
            }
            levelManager.LoadLevel();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocks : MonoBehaviour
{
    // Start is called before the first frame update

    private int numberOfEnemies;
    private bool doorsOpen =  false;
    
    public GameObject door1;
    public GameObject door2;

    public Material openDoor;

    public void checkNumOfEnemies()
    {
        // update the door once if all enemies are 0, for alpha we only want it to change colour
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (numberOfEnemies == 0)
        {
            door1.GetComponent<MeshRenderer>().material = openDoor;
            door2.GetComponent<MeshRenderer>().material = openDoor;
            doorsOpen = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!doorsOpen)
        {
            checkNumOfEnemies();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// deletes objects that don't delete between scenes
public class WorldFormatter : MonoBehaviour
{
    void Start()
    {
        Destroy(GameObject.Find("LevelManager"));
        Destroy(GameObject.Find("UFO(Clone)"));
    }
}

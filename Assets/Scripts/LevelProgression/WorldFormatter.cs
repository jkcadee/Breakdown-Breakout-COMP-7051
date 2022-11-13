using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFormatter : MonoBehaviour
{
    void Start()
    {
        Destroy(GameObject.Find("LevelManager"));
        Destroy(GameObject.Find("UFO(Clone)"));
    }
}

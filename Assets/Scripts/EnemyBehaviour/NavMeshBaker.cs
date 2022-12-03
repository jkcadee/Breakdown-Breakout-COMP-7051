using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.SceneManagement;

public class NavMeshBaker : MonoBehaviour
{
    public static NavMeshBaker Instance;

    [SerializeField]
    NavMeshSurface[] navMeshSurfaces;

    private List<GameObject> stageLevelObjects;

    private NavMeshSurface navSurface;

    // private GameObject[] walls;
    // private GameObject[] levelObjects;

    public void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        } else if (this != Instance) {
            Destroy(gameObject);
        }
    }

     void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Start is called before the first frame update
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {


        stageLevelObjects = new List<GameObject>();

        AttachNavMeshSurfaces();



        for(int i = 0; i < navMeshSurfaces.Length; i++) {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }

    void AttachNavMeshSurfaces() {
        // stageLevelObjects.Clear();
        // Array.Clear(walls, 0, walls.Length);

        // walls = GameObject.FindGameObjectsWithTag("Wall");
        // levelObjects = GameObject.FindGameObjectsWithTag("LevelObject");

        // foreach (GameObject wall in walls) {
        //     stageLevelObjects.Add(wall);
        // }

        // foreach (GameObject lo in levelObjects) {
        //     stageLevelObjects.Add(lo);
        // }

        stageLevelObjects.Add(GameObject.FindGameObjectWithTag("Floor"));
        


        foreach (GameObject o in stageLevelObjects) {
            navSurface = o.AddComponent<NavMeshSurface>() as NavMeshSurface;
        }

        navMeshSurfaces = FindObjectsOfType<NavMeshSurface>();
    }

}

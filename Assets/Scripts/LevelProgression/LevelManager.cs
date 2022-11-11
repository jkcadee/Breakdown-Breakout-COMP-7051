using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public static GameObject playerInstance;
    public GameObject player;
    public GameObject enemy;
    public static float playerHealth; 

    private int sceneNumber = 0;

    void Awake()
    {
        InstantiateManager();
    }

    void Start()
    {
        SpawnPlayer();
        SpawnEnemy();
        DontDestroyOnLoad(playerInstance);
        DontDestroyOnLoad(enemy.gameObject);
    }

    // I may need this, need to carry on health
    private void InstantiateManager ()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } else if (this != Instance)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnPlayer()
    {
        Debug.Log("Spawning player");
        playerInstance = Instantiate(player, new Vector3(0, 1, -20), Quaternion.identity);
        if (playerHealth == 0)
        {
            playerHealth = 5.0f;
        }
        playerInstance.GetComponent<PlayerControls>().health = playerHealth;
        Debug.Log(GameObject.Find("/UFO(Clone)/ShootTarget"));
        // GameObject.Find("/UFO(Clone)/ShootTarget").GetComponent<MousePoint>().mainCam = Camera.main;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        enemy.GetComponent<EnemyAI>().player = playerInstance;
    }

    public void LoadLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex != 3)
        {
            sceneNumber = 1;
        } else
        {
            sceneNumber = -1;
        }

        Debug.Log(GameObject.Find("/UFO(Clone)/ShootTarget").GetComponent<MousePoint>().mainCam.name);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNumber);
        // if (GameObject.Find("/UFO(Clone)/ShootTarget").GetComponent<MousePoint>().mainCam == null)
        // {
        //     GameObject.Find("/UFO(Clone)/ShootTarget").GetComponent<MousePoint>().mainCam = Camera.main;
        // }
        playerInstance.gameObject.transform.position = new Vector3(0, 1, -20);
    }
}

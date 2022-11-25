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
    public int numberOfEnemies;
    public static float playerHealth;
    private static float spawnCollisionRadius = 1.0f;

    private int sceneNumber = 0;

    // private string navMeshBakerPath = "Prefabs/Enemy/NavMeshBaker";

    // private GameObject navMeshBakerObject;

    public void OnSceneLoaded(Scene scene, LoadSceneMode _)
    {
        if(scene.name.Contains("Level"))
        {
            if(!playerInstance)
                SpawnPlayer();
            if(scene.name != "Level1")
                playerInstance.gameObject.transform.position = new Vector3(-35, 1, -0.3f);
            playerInstance.SetActive(true);
        } 
        else
        {
            playerInstance.SetActive(false);
        }
    }

    void Awake()
    {
        Debug.Log(Instance + "" + playerInstance);
        InstantiateManager();
    }

    void Start()
    {
        SpawnPlayer();
        //SpawnEnemy();
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (!Level_Timer.timer_on)
        {
            Level_Timer.StartTime();
        }
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

    public void ActivatePlayer()
    {
        playerInstance.SetActive(true);
    }

    public void DeactivatePlayer()
    {
        playerInstance.SetActive(false);
    }

    // Spawns the player with 5 health, sets the health in the player controls script to have the same amount
    private void SpawnPlayer()
    {
        Destroy(playerInstance);
        playerInstance = Instantiate(player, new Vector3(0, 1, -20), Quaternion.identity);
        DontDestroyOnLoad(playerInstance);
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-24, 24), 3, Random.Range(5, 20));
            if (!Physics.CheckSphere(pos, spawnCollisionRadius))
            {
                Instantiate(enemy, pos, Quaternion.identity);
                enemy.GetComponent<EnemyAI>().player = playerInstance;
                //enemy.GetComponent<SpawnBullet>().bulletPrefab 
            }
        }
    }

    // Loads a new level
    public void LoadLevel()
    {

        if(SceneManager.GetActiveScene().buildIndex != 9)
        {
            sceneNumber = 1;
        } else
        {
            sceneNumber = -1;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNumber);
        playerInstance.gameObject.transform.position = new Vector3(-35, 1, -0.3f);
        float healthToHeal = 10.0f - playerInstance.GetComponent<PlayerControls>().health;
        if (healthToHeal > 3.0000f)
        {
            healthToHeal = 3.0000f;
        }
        playerInstance.GetComponent<PlayerControls>().health += healthToHeal;
        playerHealth += healthToHeal;
        playerInstance.GetComponent<PlayerControls>().UpdateHealth();

    }
}

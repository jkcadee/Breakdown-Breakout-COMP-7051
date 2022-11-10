using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject player;
    public GameObject enemy;
    public static float playerHealth; 

    private int sceneNumber = 0;

    void Awake()
    {
        InstantiateManager();
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(enemy.gameObject);
    }

    void Start()
    {
        SpawnPlayer();
        SpawnEnemy();
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
        Instantiate(player, new Vector3(0, 1, -20), Quaternion.identity);
        if (playerHealth == 0)
        {
            playerHealth = 5.0f;
        }
        player.GetComponent<PlayerControls>().health = playerHealth;
        Debug.Log(player.GetComponent<PlayerControls>().health);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        enemy.GetComponent<EnemyAI>().player = player;
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNumber);

    }
}

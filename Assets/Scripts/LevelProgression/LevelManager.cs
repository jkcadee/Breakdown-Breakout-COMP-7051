using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    /** Overarching Singleton Level Manager for the game, handles runtime player spawning, healing when going through rooms and loading scenes*/
    public static LevelManager Instance;
    public static GameObject playerInstance;
    public GameObject player;
    public GameObject enemy;
    public int numberOfEnemies;
    public static float playerHealth;
    public GameObject muzzleFlashPrefab;

    private int sceneNumber = 0;

    private Scene currentScene;

    public GameObject GetMuzzleFlashPrefab()
    {
        return muzzleFlashPrefab;
    }

    // Loading scene for VNHandler
    public void OnSceneLoaded(Scene scene, LoadSceneMode _)
    {
        if(scene.name.Contains("Level") || scene.name.Contains("Tutorial"))
        {
            if(!playerInstance)
                SpawnPlayer();
            playerInstance.SetActive(true);
        } 
        else
        {
            playerInstance.SetActive(false);
        }
    }

    void Awake()
    {
        InstantiateManager();
    }

    void Start()
    {
        SpawnPlayer();
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (!Level_Timer.timer_on)
        {
            Level_Timer.StartTime();
        }
    }

    // Instantiates overarching level manager
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

    // Activates player
    public void ActivatePlayer()
    {
        playerInstance.SetActive(true);
    }

    // Deactivates player
    public void DeactivatePlayer()
    {
        playerInstance.SetActive(false);
    }

    // Spawns the player with 10 health, sets the health in the player controls script to have the same amount
    private void SpawnPlayer()
    {
        Destroy(playerInstance);

        currentScene = SceneManager.GetActiveScene();
        int newIndex = currentScene.buildIndex;
        if (newIndex == 2 ||
            newIndex == 3 ||
            newIndex == 4 ||
            newIndex == 6 ||
            newIndex == 12)

        {
            playerInstance = Instantiate(player, new Vector3(0, 1, -20), Quaternion.identity);

        }
        else
        {
            playerInstance = Instantiate(player, new Vector3(-35, 1, 0f), Quaternion.identity);
        }

        DontDestroyOnLoad(playerInstance);
    }

    // Loads a new level
    public void LoadLevel()
    {

        if(SceneManager.GetActiveScene().buildIndex != 14)
        {
            sceneNumber = 1;
        } else
        {
            sceneNumber = -1;
        }

        currentScene = SceneManager.GetActiveScene();
        int newIndex = currentScene.buildIndex + sceneNumber;
        SceneManager.LoadScene(newIndex);
        // Will spawn the player in a different spot depending on what scene is loaded
        if (newIndex == 2 ||
            newIndex == 3 ||
            newIndex == 4 ||
            newIndex == 5 ||
            newIndex == 12)

        {
            playerInstance.gameObject.transform.position = new Vector3(0, 1, -20f);

        }
        else
        {
            playerInstance.gameObject.transform.position = new Vector3(-35, 1, 0f);
        }

        // Healing in between rooms
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyControls : MonoBehaviour
{

    /** This code represents the Enemy's status and attributes (health, etc.)*/

    //Represents the health of the enemy
    public float health = 3f;
    public float shield;
    private float maxHealth;
    private float maxShield;

    //Represents the health meter on the enemy's healthbar that indictes
    //how much health they have.
    public GameObject health_meter;

    //Represents the health bar that hovers over the enemy.
    public GameObject health_bar;

    public GameObject enemyStats;

    public Image healthBarImage;
    //Represents the maximum distance
    // private float maxDist = 25f;

    // //Represents the minimum distance
    // private float minDist = 10f;

    //Represents the player.
    private GameObject player;

    private GameObject weaponDrop;

    private EnemyAI enemyAI;


    //Represents the distance between the player and the enemy.
    public float distance;

    private string weaponPrefabPath;
    private string assetFolder = "Prefabs/Pickup/";
    private bool isShieldedEnemyType = false;
    public EnemyShield eShield;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (GetComponent<EnemyShield>() != null)
        {
            shield = eShield.maxShield;
        } else {
            shield = 0;
        }
        
        maxHealth = health;
        maxShield = shield;
        health_bar.SetActive(false);
        enemyStats.transform.parent = null;
        enemyAI = GetComponent<EnemyAI>();

        if (maxShield != 0)
        {
            isShieldedEnemyType = true;
        }
        
    }

    /** 
        * Updates the health bar in accordance with the enemy's current health.
    */
    private void UpdateHealth()
    {
        if (shield <= 0)
        {
            health_meter.GetComponent<RectTransform>().sizeDelta = new Vector2(health / maxHealth * 5, 1);
        }
        else
        {
            health_meter.GetComponent<RectTransform>().sizeDelta = new Vector2(shield / maxShield * 5, 1);
        }

    }

    private void UpdateCanvasPosition()
    {
        enemyStats.transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y + 3f, transform.position.z + 3f);
    }

    private void OnDestroy()
    {
        Destroy(enemyStats);
    }

    /** 
     Updates each frame. It detects the distance of the enemy relative
    to the player, and displays the health meter accordingly. It also may
    trigger the enemy's anger, depending how close they are.
     */

    private void FixedUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //Debug.Log(shield);

        healthBarImage = health_meter.GetComponent<Image>();

        // Debug.Log(weaponPrefabPath);
        weaponPrefabPath = assetFolder + enemyAI.bulletType;

        weaponDrop = (GameObject)Resources.Load(weaponPrefabPath, typeof(GameObject));

        if (health < 1)
        {
            AudioController.PlayDeath();
            Instantiate(weaponDrop, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        UpdateHealth();
        UpdateCanvasPosition();
        distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);


        if (isShieldedEnemyType)
        {
            if (health == maxHealth && shield == maxShield)
            {
                health_bar.SetActive(false);
            }
            else if (shield != maxShield && shield > 0)
            {
                healthBarImage.color = new Color(0, 175 / 255f, 45 / 255f);
                health_bar.SetActive(true);
            }
            else
            {
                healthBarImage.color = new Color(255 / 255f, 0, 0);
                health_bar.SetActive(true);
            }
        }
        else
        {
            if (health == maxHealth)
            {
                health_bar.SetActive(false);
            }
            else
            {
                health_bar.SetActive(true);
            }
        }

    }
}

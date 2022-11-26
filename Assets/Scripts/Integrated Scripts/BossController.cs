using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossController : MonoBehaviour
{

    /** This code represents the Enemy's status and attributes (health, etc.)*/

    //Represents the health of the enemy
    public float health = 5f;
    
    public float healthBarCounter = 3f;


    private float maxHealth;


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


    private EnemyAI enemyAI;

    public Material mMaterial;

    //Represents the distance between the player and the enemy.
    public float distance;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Debug.Log(this.name + (GetComponent<BossShield>() != null));

        maxHealth = health;
        health_bar.SetActive(false);
        enemyStats.transform.SetParent(null);
        enemyAI = GetComponent<EnemyAI>();
        mMaterial.color = new Color(0f, 0f, 0f);

    }

    /** 
        * Updates the health bar in accordance with the enemy's current health.
    */
    private void UpdateHealth()
    {


        health_meter.GetComponent<RectTransform>().sizeDelta = new Vector2(health / maxHealth * 5, 1);


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

        if (healthBarCounter == 2) {
        GetComponent<SpawnBullet>().bulletPrefab = (GameObject)Resources.Load("Prefabs/Shooting/SpreadBullet", typeof(GameObject));
        mMaterial.color = new Color(0f, 175f / 255f, 255f);
        healthBarImage.color = new Color(0f, 175f / 255f, 255f);
        }

        if (healthBarCounter == 1) {
        
        GetComponent<SpawnBullet>().bulletPrefab = (GameObject)Resources.Load("Prefabs/Shooting/BossExplosion", typeof(GameObject));
        mMaterial.color = new Color(255f, 100f / 255f, 0f);
        healthBarImage.color = new Color(255f, 100f / 255f, 0f);
        }

        if (healthBarCounter == 0) {
        GetComponent<SpawnBullet>().bulletPrefab = (GameObject)Resources.Load("Prefabs/Shooting/BossBounce", typeof(GameObject));
        mMaterial.color = new Color(0f, 255f, 75 / 255f);
        healthBarImage.color = new Color(0f, 255f, 75 / 255f);
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //Debug.Log(shield);

        healthBarImage = health_meter.GetComponent<Image>();


        if (health < 1 && healthBarCounter <= 0)
        {

            AudioController.PlayDeath();

            Destroy(gameObject);

        } else if (health < 1) 
        {
            healthBarCounter -= 1;
            health = maxHealth;
        }

        UpdateHealth();
        UpdateCanvasPosition();
        distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);


        if (health == maxHealth && healthBarCounter == 3)
        {
            health_bar.SetActive(false);
        }
 
        else if (healthBarCounter < 3) 
        {
            health_bar.SetActive(true);
        }
        else
        {

            health_bar.SetActive(true);
        }

    }
}

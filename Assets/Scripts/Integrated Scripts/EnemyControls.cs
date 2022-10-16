using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{

    /** This code represents the Enemy's status and attributes (health, etc.)*/

    //Represents the health of the enemy
    public float health = 4f;
    private float maxHealth;

    //Represents the health meter on the enemy's healthbar that indictes
    //how much health they have.
    public GameObject health_meter;

    //Represents the health bar that hovers over the enemy.
    public GameObject health_bar;

    public GameObject enemyStats;

    //Represents the maximum distance
    private float maxDist = 25f;

    //Represents the minimum distance
    private float minDist = 10f;

    //Represents the player.
    private GameObject player;

    public GameObject weaponDrop;

    private EnemyAI enemyAI;

    //Represents the distance between the player and the enemy.
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        maxHealth = health;
        health_bar.SetActive(false);
        enemyStats.transform.parent = null;
        enemyAI = GetComponent<EnemyAI>();
    }

    /** 
        * Updates the health bar in accordance with the enemy's current health.
    */
    private void UpdateHealth()
    {

        health_meter.GetComponent<RectTransform>().sizeDelta = new Vector2(health/maxHealth * 5, 1);

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

        if (health < 1)
        {
            Instantiate(weaponDrop, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

        UpdateHealth();
        UpdateCanvasPosition();
        distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if (distance >= maxDist)
        {
            health_bar.SetActive(false);
        }
        else
        {
            health_bar.SetActive(true);
        }
    }
}

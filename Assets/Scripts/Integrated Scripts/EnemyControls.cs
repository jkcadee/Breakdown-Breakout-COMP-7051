using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{

    /** This code represents the Enemy's status and attributes (health, etc.)*/

    //Represents the health of the player
    public float health;

    //Represents the health meter on the enemy's healthbar that indictes
    //how much health they have.
    public GameObject health_meter;

    //Represents the health bar that hovers over the enemy.
    public GameObject health_bar;

    //Represents the maximum distance
    private float maxDist = 25f;

    //Represents the minimum distance
    private float minDist = 10f;

    //Represents the player.
    private GameObject player;

    public GameObject weaponDrop;

    //Represents the distance between the player and the enemy.
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = 2.0f;
        health_bar.SetActive(false);
    }

    /** 
    Detects if the enemy enters a trigger.
    If it collides with a bullet, the enemy takes damage.
    @param other
     */

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Bullet")
    //     {
    //         TakeDamage();
    //     }
    // }

    /** 
        * Updates the health bar in accordance with the enemy's current health.
    */
    private void UpdateHealth()
    {

        health_meter.GetComponent<RectTransform>().sizeDelta = new Vector2(health * 1, 1);

    }

    /** 
      * Decrements the enemy's health by one.
    */
    // private void TakeDamage()
    // {
    //     if (health > 0.0f)
    //     {
    //         health -= 1.0f;
    //         UpdateHealth();
    //     }
    //     //Checks the enemy's health
    //     //If it is less than or equal to 2, enemy dies.
    //     if (health <= 0.0f)
    //     {
    //         Die();
    //     }
    // }

    /** 
        Increments the enemy's health by one.
    */
    // private void Heal()
    // {
    //     health += 1.0f;
    //     UpdateHealth();
    // }

    /** Destroys the enemy. */

    // private void Die()
    // {

    //     Destroy(gameObject);

    // }

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
        distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if (distance >= maxDist)
        {
            health_bar.SetActive(true);
        }
        else if (distance <= minDist)
        {
            health_bar.SetActive(true);
        }
        else
        {
            health_bar.SetActive(false);
        }
    }
}

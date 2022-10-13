using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{

    //Represents the health of the player
    private float health;

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

    //Represents the speed of the enemy.
    public float moveSpeed = 5f;

    //Represents the visibility of the player.
    private bool isVisible = false;

    //Represents how long the enemy will be angry for.
    public float angerTimer;

    //JAY-COMMENT
    public UnityEngine.AI.NavMeshAgent _agent;

    //Represents the distance between the player and the enemy.
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = 5.0f;
        health_bar.SetActive(false);
    }

    /** 
    Detects if the enemy enters a trigger.
    If it collides with a bullet, the enemy takes damage.
    @param other
     */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
    }

    /** 
        * Updates the health bar in accordance with the enemy's current health.
    */
    private void UpdateHealth()
    {

        health_meter.GetComponent<RectTransform>().sizeDelta = new Vector2(health*1, 1);

    }

    /** 
      * Decrements the enemy's health by one.
    */
    private void TakeDamage()
    {
        if (health > 0.0f) {
            health -= 1.0f;
            UpdateHealth();
        }
        //Checks the enemy's health
        //If it is less than or equal to 2, enemy dies.
        if (health <= 0.0f)
        {
            Die();
        }
    }

    /** 
        Increments the enemy's health by one.
    */
    private void Heal()
    {
        health += 1.0f;
        UpdateHealth();
    }

    /** Destroys the enemy. */

    private void Die() {

        Destroy(gameObject);
    
    }

    /** 
     Updates each frame. It detects the distance of the enemy relative
    to the player, and displays the health meter accordingly. It also may
    trigger the enemy's anger, depending how close they are.
     */

    private void FixedUpdate()
    {
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

        if (distance >= maxDist || (!isPlayerVisible() && angerTimer <= 0))
        {
            _agent.isStopped = true;
        }
        else if (distance <= minDist && (isPlayerVisible() || angerTimer > 0))
        {
            _agent.isStopped = true;
            transform.LookAt(player.transform);
        }
        else
        {
            _agent.isStopped = false;
            transform.LookAt(player.transform);
            _agent.SetDestination(player.transform.localPosition);
            // transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    /** JAY'S COMMENT */

    private bool isPlayerVisible()
    {
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        RaycastHit hit;
        if (Physics.Raycast(transform.localPosition, direction, out hit))
        {
            if (hit.transform.tag.Equals("Player"))
            {
                isVisible = true;
                angerTimer = 2.5f;
            }
            else
            {
                isVisible = false;
                angerTimer -= Time.deltaTime;
            }
        }
        return isVisible;
    }
}

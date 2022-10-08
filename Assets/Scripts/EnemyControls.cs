using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    //Represents the health of the player
    private float health;

    //Represents the health bar of the player.
    public GameObject health_meter;

    public GameObject health_bar;

    private Vector3 tvec = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        health = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tvec.Set(0, 0, 1);
            transform.Translate(tvec);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tvec.Set(-1, 0, 0);
            transform.Translate(tvec);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tvec.Set(1, 0, 0);
            transform.Translate(tvec);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tvec.Set(0, 0, -1);
            transform.Translate(tvec);
        }
        //Vector3 newpos = new Vector3(transform.position.x, health_bar.GetComponent<RectTransform>().position.y, health_bar.GetComponent<RectTransform>().position.z);
        //health_bar.transform.position = newpos;
    }

    /** 
        * Updates the health bar in accordance with the enemy's current health.
    */
    private void UpdateHealth()
    {

        health_meter.GetComponent<RectTransform>().sizeDelta = new Vector2(health, 15);

    }

    /** 
      * Decrements the enemy's health by one.
    */
    private void TakeDamage()
    {
        health -= 1.0f;
        UpdateHealth();
    }

    /** 
        Increments the enemy's health by one.
    */
    private void Heal()
    {
        health += 1.0f;
        UpdateHealth();
    }
}

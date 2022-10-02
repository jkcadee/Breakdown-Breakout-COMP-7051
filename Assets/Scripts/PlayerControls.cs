using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    //create private internal references
    private InputActions inputActions;

    //Represents the movment inputaction
    private InputAction movement;

    //Represents the health of the player
    private float health;

    //Represents the health bar of the player.
    public GameObject health_meter;

    Rigidbody rb;

    /** 
     Sets up the value of the player's health.
     */

    private void Start() {
        health = 5.0f;
        UpdateHealth();
    }

    /** 
     * Instantiates the input action object.
     */

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new InputActions(); //create new InputActions
    }

    /**
     Enables the movement controls.
     */
    private void OnEnable()
    {
        movement = inputActions.Player.Movement; //get reference to movement action
        movement.Enable();
    }

    /**
        Disables the movement controls.
     */
    private void OnDisable()
    {
        movement.Disable();
    }
    /** 
     Updates the movement as the controls are pressed.
     */
    private void FixedUpdate()
    {
        Vector2 v2 = movement.ReadValue<Vector2>(); //extract 2d input data
        Vector3 v3 = new Vector3(v2.x * 1.0f, 0, v2.y); //convert to 3d space
        //transform.Translate(v3);
        rb.AddForce(v3, ForceMode.VelocityChange);

    }

    /** 
     * Updates the health bar in accordance with the player's current health.
     */
    private void UpdateHealth() {

        health_meter.GetComponent<RectTransform>().sizeDelta = new Vector2(health*30, 23.9f) ;

    }

    /** 
     * Decrements the player's health by one.
    */
    private void TakeDamage() {
        health -= 1.0f;
        UpdateHealth();
    }

    /** 
       Increments the player's health by one.
    */
    private void Heal() {
        health += 1.0f;
        UpdateHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            TakeDamage();
        }
    }

    void Update() {

    }
}

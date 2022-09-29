using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    //create private internal references
    private InputActions inputActions;
    private InputAction movement;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody, responsible for enabling collision with other colliders
        inputActions = new InputActions(); //create new InputActions
    }
    //called when script enabled
    private void OnEnable()
    {
        movement = inputActions.Player.Movement; //get reference to movement action
        movement.Enable();
    }
    //called when script disabled
    private void OnDisable()
    {
        movement.Disable();
    }
    //called every physics update
    private void FixedUpdate()
    {
        Vector2 v2 = movement.ReadValue<Vector2>(); //extract 2d input data
        Vector3 v3 = new Vector3(v2.x * 0.2f, 0, v2.y); //convert to 3d space
        //Debug.Log(v2.x);
        //Debug.Log(v2.y);
        transform.Translate(v3);

    }
}

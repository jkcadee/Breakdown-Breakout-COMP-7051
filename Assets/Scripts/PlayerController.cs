using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction movement;
    private InputActions inputActions;
    Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        inputActions = new InputActions();

        movement = inputActions.Player.Movement;

    }

    private void OnEnable() {
        movement.Enable();
    }

    public void OnDisable() {
        movement.Disable();
    }

    private void FixedUpdate() {
        Vector2 v2 = movement.ReadValue<Vector2>();

        Vector3 v3 = new Vector3(v2.x, 0, v2.y);

        rb.AddForce(v3, ForceMode.VelocityChange);
    }
}

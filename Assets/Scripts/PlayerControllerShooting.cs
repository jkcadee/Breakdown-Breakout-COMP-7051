using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerShooting : MonoBehaviour
{
    private InputAction movement;
    private InputActions inputActions;
    Rigidbody rb;

    private Vector2 mousePos;
    Vector3 m_EulerAngleVelocity;
    public Weapon weapon;

    private float rotX;
    private float rotY;
    public float speed = 100f;

    private InputActionReference Shoot;

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

    public void Update(){
        mousePos = Mouse.current.position.ReadValue();
        Debug.Log(mousePos.x);
        Debug.Log(mousePos.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos); 
    }

    public void onShoot(InputValue value){
        Debug.Log("fire");
        weapon.Fire();
    }

    private void FixedUpdate() {
        Vector2 v2 = movement.ReadValue<Vector2>();

        Vector3 v3 = new Vector3(v2.x, 0, v2.y);

        rb.AddForce(v3, ForceMode.VelocityChange);
         
        Vector2 modifiedPos = new Vector2(rb.position.x,rb.position.z);
        Vector2 aimDirection = mousePos - modifiedPos;
        float aimAngle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg - 90;
        Debug.Log(aimAngle);
        transform.rotation = Quaternion.Euler(new Vector3(0, -aimAngle, 0));
        // m_EulerAngleVelocity = new Vector3(0, aimAngle, 0);
        // Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        // //rb.MoveRotation( rb.rotation * deltaRotation);
        // rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0f, aimAngle, 0f))


    }
}

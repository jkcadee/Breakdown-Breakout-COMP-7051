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

    private Camera mainCamera;

    // private InputAction shoot;
    Plane groundPlane;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        inputActions = new InputActions();
        //shoot = inputActions.Player.Shoot;
        movement = inputActions.Player.Movement;
        groundPlane = new Plane(Vector3.up, Vector3.zero);


    }

    private void OnEnable() {
        movement.Enable();
        //shoot.Enable();
        //shoot.performed += Shoot;
    }

    public void OnDisable() {
        movement.Disable();
        //shoot.performed -= Shoot;
        //shoot.Disable();
    }

    //   public void Shoot(InputAction.CallbackContext obj){
    //     weapon.onShoot();
    // }

    public void Update(){
        mousePos = Mouse.current.position.ReadValue();
        // https://www.youtube.com/watch?v=lkDGk3TjsIE
        // aiming code
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        float rayLength = 0;

        if(groundPlane.Raycast(cameraRay, out rayLength)){
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin,pointToLook, Color.blue);
            transform.LookAt(new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
        }

    }

    private void FixedUpdate() {
        Vector2 v2 = movement.ReadValue<Vector2>();

        Vector3 v3 = new Vector3(v2.x, 0, v2.y);

        rb.AddForce(v3, ForceMode.VelocityChange);
    }
}

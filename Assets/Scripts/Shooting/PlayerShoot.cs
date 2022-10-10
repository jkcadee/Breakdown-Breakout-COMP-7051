using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private SpawnBullet sb;
    public GameObject target;
    private InputActions inputActions;
    private InputAction shootAction;

    public float shootCooldown = 0.3f;
    private float timer = 0;

    private bool shooting = false;

    private void Awake()
    {
        inputActions = new InputActions();
    }

    void Start()
    {
        sb = GetComponent<SpawnBullet>();
    }

    private void OnEnable()
    {
        shootAction = inputActions.Player.Shoot;
        shootAction.performed += StartShooting;
        shootAction.canceled += StopShooting;
        shootAction.Enable();
    }

    void StartShooting(InputAction.CallbackContext obj)
    {
        shooting = true;
    }

    void StopShooting(InputAction.CallbackContext obj)
    {
        shooting = false;
    }

    void Shoot()
    {
        if (timer > 0) 
            return;

        sb.ShootAtTarget(target.transform.position);
        timer = shootCooldown;
    }

    void Update()
    {
        if (shooting)
            Shoot();

        if (timer > 0)
            timer -= Time.deltaTime;
    }
}

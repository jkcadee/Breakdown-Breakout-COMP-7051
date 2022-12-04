using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private SpawnBullet sb;
    private PickupNouveau pn;
    public GameObject target;
    public GameObject defaultBullet;
    private InputActions inputActions;
    private InputAction shootAction;
    private int ammo = 0;

    private float timer = 0;

    private bool shooting = false;

    private void Awake()
    {
        inputActions = new InputActions();
    }

    void Start()
    {
        sb = GetComponent<SpawnBullet>();
        pn = GetComponent<PickupNouveau>();
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

    public void SetAmmo(int a)
    {
        ammo = a;
    }

    public int GetAmmo()
    {
        return ammo;
    }

    // can only shoot while the cooldown timer isn't active
    void Shoot()
    {
        if (timer > 0) 
            return;

        sb.ShootAtTarget(target.transform.position);

        ammo--;
        if(ammo <= 0)
        {
            sb.SetBulletPrefab(defaultBullet);
            pn.ResetToDefault();
        }

        timer = sb.bulletPrefab.GetComponent<BulletBehaviour>().shootCooldown;
    }

    void Update()
    {
        if (shooting)
            Shoot();

        if (timer > 0)
            timer -= Time.deltaTime;
    }
}

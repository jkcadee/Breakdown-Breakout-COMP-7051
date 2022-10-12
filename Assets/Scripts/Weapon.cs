using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
//https://www.youtube.com/watch?v=wZ2UUOC17AY
public class Weapon : MonoBehaviour
{
//bullet 
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    //public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;

    private InputActions inputActions;
    
    private InputAction shoot;

    private InputAction reload;

    Plane groundPlane;

    private Vector2 mousePos;

    private Camera mainCamera;


    private void Awake()
    {
        //make sure magazine is full
        inputActions = new InputActions();
        mainCamera = FindObjectOfType<Camera>();
        bulletsLeft = magazineSize;
        readyToShoot = true;
        shoot = inputActions.Player.Shoot;
        reload = inputActions.Player.Reload;
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    private void OnEnable() {
        shoot.Enable();
        shoot.performed += onShoot;
        reload.Enable();
        reload.performed += OnReload;
    }

    public void OnDisable() {
        shoot.performed -= onShoot;
        shoot.Disable();
        reload.Disable();
        reload.performed -= OnReload;
    }

    private void Update()
    {
        //MyInput();

        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }

    public void onShoot(InputAction.CallbackContext obj){

        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();
        Debug.Log("fire");
        Debug.Log(readyToShoot + " " + reloading +  " " +  bulletsLeft);
        if (readyToShoot && !reloading && bulletsLeft > 0)
        {
            Debug.Log("firing");
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }

        
    }

    public void OnReload(InputAction.CallbackContext obj){
        if (bulletsLeft < magazineSize && !reloading){
            Reload();
        }

    }

    public void Shoot()
    {
        readyToShoot = false;
        mousePos = Mouse.current.position.ReadValue();
        // https://www.youtube.com/watch?v=lkDGk3TjsIE
        // aiming code
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        float rayLength = 0;

        Vector3 pointToLook = Vector3.zero;

        if(groundPlane.Raycast(cameraRay, out rayLength)){
            pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin,pointToLook, Color.blue);
        }
         Vector3 directionWithoutSpread = new Vector3 (pointToLook.x, attackPoint.position.y, pointToLook.z) - attackPoint.position;
        //Vector3 directionWithoutSpread = new Vector3(attackPoint.position.x,attackPoint.position.y,attackPoint.position.z);

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread;//Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithoutSpread;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        
        //Instantiate muzzle flash, if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        Debug.Log("Reloading");
        reloading = true;
        Invoke("ReloadFinished", reloadTime); //Invoke ReloadFinished function with your reloadTime as delay
    }
    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }
}

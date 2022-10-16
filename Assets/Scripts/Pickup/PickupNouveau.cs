using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PickupNouveau : MonoBehaviour
{
    private InputActions inputActions;
    private InputAction pickup;
    private GameObject pickupItem;
    private SpawnBullet sb;
    public GameObject gun;

    private void Awake()
    {
        inputActions = new InputActions();
        pickup = inputActions.Player.Pickup;
        sb = GetComponent<SpawnBullet>();
        ChangeIcon(Color.black);
        gun.GetComponent<Renderer>().material.color = Color.black;
    }

    public void OnEnable()
    {
        pickup.Enable();
        pickup.performed += GrabPickupItem;
    }

    private void OnDisable()
    {
        pickup.Disable();
        pickup.performed -= GrabPickupItem;
    }

    private void ChangeIcon(Color colour)
    {
        GameObject weapon_image = GameObject.FindGameObjectWithTag("Status_Image");
        weapon_image.GetComponent<Image>().color = colour;
    }

    public void GrabPickupItem(InputAction.CallbackContext _)
    {
        // can only pickup if in range of an item pickup
        if (!pickupItem) 
            return;

        ItemPickupBehaviour ipb = pickupItem.GetComponent<ItemPickupBehaviour>();

        GameObject sbBulletPrefab = sb.bulletPrefab;
        sb.bulletPrefab = ipb.bulletPrefab;
        ipb.bulletPrefab = sbBulletPrefab;

        Renderer gunRenderer = gun.GetComponent<Renderer>();
        Renderer pickupRenderer = pickupItem.GetComponent<Renderer>();

        Debug.Log("g1 " + gunRenderer.material.color);
        Debug.Log("p1 " + pickupRenderer.material.color);

        Color gunColour = gunRenderer.material.color;
        gunRenderer.material.color = pickupRenderer.material.color;
        pickupRenderer.material.color = gunColour;

        Debug.Log("g2 " + gunRenderer.material.color);
        Debug.Log("p2 " + pickupRenderer.material.color);

        ChangeIcon(gunRenderer.material.color);
    }

    public void SetPickupItem(GameObject pi)
    {
        pickupItem = pi;
    }

    public GameObject GetPickupItem()
    {
        return pickupItem;
    }
}

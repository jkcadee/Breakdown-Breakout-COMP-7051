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
        ChangeColour(Color.white);
        gun.GetComponent<Renderer>().material.color = Color.white;
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

    private void ChangeColour(Color colour)
    {
        GameObject weapon_image = GameObject.FindGameObjectWithTag("Status_Image");
        weapon_image.GetComponent<Image>().color = colour;
    }

    private void ChangeIcon(Sprite sprite)
    {
        GameObject weapon_image = GameObject.FindGameObjectWithTag("Status_Image");
        weapon_image.GetComponent<Image>().sprite = sprite;
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

        ChangeColour(gunRenderer.material.color);
        ChangeIcon(ipb.startSprite);
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

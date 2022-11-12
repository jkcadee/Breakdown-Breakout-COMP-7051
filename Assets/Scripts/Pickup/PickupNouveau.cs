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
    private PlayerShoot ps;
    public GameObject gun;
    public Sprite defaultGunSprite;

    private void Awake()
    {
        inputActions = new InputActions();
        pickup = inputActions.Player.Pickup;
        sb = GetComponent<SpawnBullet>();
        ps = GetComponent<PlayerShoot>();
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

    public void ResetToDefault()
    {
        ChangeColour(Color.white);
        ChangeIcon(defaultGunSprite);
        gun.GetComponent<Renderer>().material.color = Color.black;
    }

    public void GrabPickupItem(InputAction.CallbackContext _)
    {
        // can only pickup if in range of an item pickup
        if (!pickupItem) 
            return;

        ItemPickupBehaviour ipb = pickupItem.GetComponent<ItemPickupBehaviour>();
        sb.bulletPrefab = ipb.bulletPrefab;

        Renderer gunRenderer = gun.GetComponent<Renderer>();
        Renderer pickupRenderer = pickupItem.GetComponent<Renderer>();

        gunRenderer.material.color = pickupRenderer.material.color;

        ChangeColour(gunRenderer.material.color);
        ChangeIcon(ipb.startSprite);
        ps.SetAmmo(sb.bulletPrefab.GetComponent<BulletBehaviour>().ammo);

        Destroy(pickupItem);

        AudioController.PlayPickup();
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

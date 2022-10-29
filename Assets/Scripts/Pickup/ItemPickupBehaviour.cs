using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Color startColor;
    public Sprite startSprite;
    private PickupNouveau player;

    private void Start()
    {
        //GetComponent<Image>().sprite = startSprite;
        GetComponent<Renderer>().material.color = startColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player enters the trigger for this pickup, set the player's pickup item to this
        if(other.tag == "Player")
        {
            player = other.gameObject.GetComponent<PickupNouveau>();
            player.SetPickupItem(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if player leaves the trigger and the selected pickup item is still this, remove the player's pickup item
        if (other.tag == "Player" && player.GetPickupItem() == gameObject)
        {
            player.SetPickupItem(null);
        }
    }
}

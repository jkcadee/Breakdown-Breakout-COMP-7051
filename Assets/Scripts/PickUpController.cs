using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpController : MonoBehaviour
{
   public Weapon gunScript;
   public Rigidbody rb;
   public BoxCollider coll;
   public Transform player, gunContainer, attackPoint;

   public float pickUpRange;
   public float dropForwardForce,dropUpwardForce;

   public bool equipped;
   public static bool slotFull;

   Vector3 distanceToPlayer;

   private InputActions inputActions;

   private InputAction drop;

    private InputAction pickup;

    private void Awake(){
        inputActions = new InputActions();
        drop = inputActions.Player.Drop;
        pickup = inputActions.Player.Pickup;
        distanceToPlayer = player.position - transform.position;
    }

    private void OnEnable() {
        drop.Enable();
        drop.performed += onDrop;
        pickup.Enable();
        pickup.performed += onPickup;
    }

    public void OnDisable() {
        drop.Disable();
        drop.performed -= onDrop;
        pickup.Disable();
        pickup.performed -= onPickup;
    }

    private void onPickup(InputAction.CallbackContext obj){
        Debug.Log("pickup");
        Vector3 distanceToPlayer = player.position - transform.position;
        Debug.Log(distanceToPlayer);
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull){
            PickUp();
        } 
    }

    private void onDrop(InputAction.CallbackContext obj){
        Debug.Log("dropping");
        if (equipped) Drop();
    }

   private void Start()
    {
        //Setup
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        distanceToPlayer = player.position - transform.position;

    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(player);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.one;

        
        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(attackPoint.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(attackPoint.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //Disable script
        gunScript.enabled = false;
    }

}

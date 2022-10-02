using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    public float maxDist = 25f;
    public float minDist = 10f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform);

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if  (distance <= maxDist && distance >= minDist) {
            transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}

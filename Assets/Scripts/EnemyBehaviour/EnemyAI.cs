using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    public float maxDist = 25f;
    public float minDist = 10f;
    private bool isVisible = false;
    public float angerTimer;
    public NavMeshAgent _agent;
    public float distance;

    private float timer = 0;
    private SpawnBullet sb;
    private bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sb = GetComponent<SpawnBullet>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);


        if (distance >= maxDist || (!isPlayerVisible() && angerTimer <= 0))
        {
            _agent.isStopped = true;
            Debug.Log("NOT SHOOTING ANYMORE!!!");
        }
        else if (distance <= minDist && (isPlayerVisible() || angerTimer > 0))
        {
            _agent.isStopped = true;
            transform.LookAt(player.transform);
            Shoot();
        }
        else
        {

            _agent.isStopped = false;
            transform.LookAt(player.transform);
            _agent.SetDestination(player.transform.localPosition);
            Shoot();
            // transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private bool isPlayerVisible()
    {
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        RaycastHit hit;
        if (Physics.Raycast(transform.localPosition, direction, out hit))
        {
            if (hit.transform.tag.Equals("Player"))
            {
                isVisible = true;
                angerTimer = 2f;
            }
            else
            {
                isVisible = false;
                angerTimer -= Time.deltaTime;
            }
        }
        return isVisible;
    }
    void Shoot()
    {

        sb.ShootAtTarget(player.transform.position);

        Debug.Log("SHOT FIRED!!!");
    }
}

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

    private BulletBehaviour bb;
    private bool shooting = false;
    [SerializeField] private float weaponCooldown = 0.5f;
    private float _fireTimer;

    public LayerMask bulletlayer;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sb = GetComponent<SpawnBullet>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        distance = Vector3.Distance(transform.position, player.transform.position);


        if (distance >= maxDist || (!isPlayerVisible() && angerTimer <= 0))
        {
            _agent.isStopped = true;
        }
        else if (distance <= minDist && (isPlayerVisible() || angerTimer > 0))
        {
            _agent.isStopped = true;
            transform.LookAt(player.transform);

            if (Time.time > _fireTimer)
            {
                _fireTimer = Time.time + weaponCooldown;
                Shoot();
            }


        }
        else
        {
            _agent.isStopped = false;
            transform.LookAt(player.transform);
            _agent.SetDestination(player.transform.position);

            if (Time.time > _fireTimer)
            {
                _fireTimer = Time.time + weaponCooldown;
                Shoot();
            }

            // transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

    }

    public bool GetIsPlayerVisible()
    {
        return isVisible;
    }

    private bool isPlayerVisible()
    {
        Vector3 direction = player.transform.position - transform.position;
        RaycastHit hit;
        bulletlayer = ~bulletlayer;
        if (Physics.Raycast(transform.position, direction, out hit, 500f, bulletlayer))
        {

            if (hit.collider.gameObject.name == ("UFO"))
            {

                isVisible = true;
                angerTimer = 2.5f;
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


    }
}

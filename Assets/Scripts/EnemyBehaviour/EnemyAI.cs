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

    // private float timer = 0;
    private SpawnBullet sb;

    // private BulletBehaviour bb;
    // private bool shooting = false;
    [SerializeField] private float weaponCooldown;
    private float _fireTimer;

    public LayerMask bulletlayer;
    public string bulletType;

    private string weaponName;
    private float inaccuraty = 2f;
    private Vector3 enemyAim;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sb = GetComponent<SpawnBullet>();
        weaponCooldown = sb.bulletPrefab.GetComponent<BulletBehaviour>().shootCooldown;
        weaponName = sb.bulletPrefab.transform.name;
        bulletType = "AT_Pickup" + weaponName;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        distance = Vector3.Distance(transform.position, player.transform.position);

        isVisible = isPlayerVisible();

        if (angerTimer > 0)
        {
            if (distance <= minDist)
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
            }
        }
        else {
             _agent.isStopped = true;
        }
    }


    private bool isPlayerVisible()
    {
        Vector3 direction = player.transform.position - transform.position;
        RaycastHit hit;
        bulletlayer = ~bulletlayer;
        if (Physics.Raycast(transform.position, direction, out hit, 500f, bulletlayer))
        {

            if (hit.collider.gameObject.tag == ("Player") && distance < maxDist)
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
        Vector2 rand = Random.insideUnitCircle;
        enemyAim = player.transform.position + new Vector3(rand.x, 0, rand.y) * inaccuraty;
        sb.ShootAtTarget(enemyAim);

    }    public bool correctBullet;

}
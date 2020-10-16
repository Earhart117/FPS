using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    protected NavMeshAgent Agent;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    int health = 100;

    public GameObject projectile;
    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    public void TakeDamage(int _damageToTake)
    {
        health -= _damageToTake;
        Debug.Log(health + " health remaining");
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
            else if(Vector3.Distance(transform.position, player.position) < retreatDistance)
                {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                }

        if (timeBtwShots <=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (health <=0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        enemy.SetActive(false);
    }
}

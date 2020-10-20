using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Text _currentScoreTextView;
    public AudioSource _enemyFire;
    protected NavMeshAgent Agent;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float attackDistance = 10f;
    public float followDistance = 20f;
    public Transform player;
    int health = 100;
    int points = 20;
    [Range(0f, 1f)]
    public float attackProbability = .5f;

    [Range(0f, 1f)]
    public float hitAccuracy = .5f;

    [SerializeField] GameObject projectilePrefab;
    public GameObject _projectile;

    public float timeBtwShots;
    public float startTimeBtwShots;
    Level01Controller level01Controller;

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
        if (Agent.enabled)
        {
            float dist = Vector3.Distance(player.transform.position, this.transform.position);
            bool shoot = false;
            bool follow = (dist < followDistance);

            if (follow)
            {
                float random = Random.Range(0f, 1f);
                if (random > (1f - attackProbability) && (dist <= attackDistance) && (timeBtwShots <= 0))
                {
                    shoot = true;
                    _enemyFire.Play();
                    _projectile = Instantiate(projectilePrefab) as GameObject;
                    _projectile.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _projectile.transform.rotation = transform.rotation;
                    // Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                    //Debug.Log("calling first if");
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                    //Debug.Log("calling else");
                }
                if (follow)
                {
                    Agent.SetDestination(player.transform.position);
                }
                if (!follow || shoot)
                {
                    Agent.SetDestination(transform.position);
                }

                else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

                }
            }
            if (health <= 0)
            {

                
                KillEnemy();

            }
        }



        void KillEnemy()
        {
            enemy.SetActive(false);
        }
    
    }
}

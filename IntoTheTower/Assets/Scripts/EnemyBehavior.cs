using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    ////Patrolling
    //public Vector3 walkPoint;
    //bool walkPointSet;
    //public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public bool dead;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        //agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //if (!playerInSightRange && !playerInAttackRange)
        //    Patrolling();
        //if (playerInSightRange && !playerInAttackRange)
        //    ChasePlayer();
        if (playerInSightRange && playerInAttackRange)
            AttackPlayer();
    }

    //private void Patrolling()
    //{
    //    if (!walkPointSet)
    //        SearchWalkPoint();
    //    if (walkPointSet)
    //        agent.SetDestination(walkPoint);

    //    Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //    //Walkpoint reached
    //    if (distanceToWalkPoint.magnitude < 1f)
    //        walkPointSet = false;
    //}

    //private void SearchWalkPoint()
    //{
    //    // calc random point in range
    //    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //    float randomX = Random.Range(-walkPointRange, walkPointRange);

    //    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    //    if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //    {
    //        walkPointSet = true;
    //    }
    //}

    //private void ChasePlayer()
    //{
    //    agent.SetDestination(player.position);
    //}

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            //Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position + transform.forward, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up, ForceMode.Impulse);


            ///


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    } 

    //Animation
    public Animator enemy;
    private int hp = 5; //Private value for hp
    public int enemyHP { get { return hp; }  //Get Doesn't need any functions, since we only need to check hp when changed
        set 
        { hp = value; //Set hp equal to what it is supposed to be
            enemy.SetTrigger("Hit");
            if (hp <= 0)
            { //if has no HP left, disable the gameobject
                enemy.SetTrigger("Dead");
            }
        } 
    }

    public void Die()
    {
        GameManager.instance.enemiesLeft--;
        this.gameObject.SetActive(false); //Change to Destroy(this.gameObject) when having multiple enemies spawn in and die
    }
    public void Start()
    {
        GameManager.instance.enemiesLeft++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public EnemyBehavior enemyBehavior;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public Transform attackZoneCenter;
    public float attackZoneRadius;
    //States
    //public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, enemyBehavior.sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, enemyBehavior.attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange /*&& !PlayerInZone()*/)
            Patrolling();
        if (playerInSightRange && !enemyBehavior.enemyDead /* && !playerInAttackRange*/ /*&& PlayerInZone()*/)
            ChasePlayer();
       // if (playerInSightRange && playerInAttackRange)
            //AttackPlayer();
    }

    private void Patrolling()
    {
        if (!walkPointSet)
            SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        // calc random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(attackZoneCenter.position.x + randomX, attackZoneCenter.position.y, attackZoneCenter.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        walkPointSet = false;
    }

    public bool PlayerInZone()
    {
        float distance = Vector3.Distance(attackZoneCenter.position, player.transform.position);

        if (distance < attackZoneRadius)
            return true;
        else
            return false;
    }
}

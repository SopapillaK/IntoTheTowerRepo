using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public EnemyWeaponController weaponController; //Called myy class

    //Attacking
    //public float timeBetweenAttacks;
    //bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public bool enemyDead = false;

    [SerializeField] Healthbar enemyhealthbar;

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
       
        if (!enemyDead)
        {
            if (playerInSightRange && playerInAttackRange)
                AttackPlayer();
        }  
    }


    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        //if (!alreadyAttacked)
        //{
            //Attack code here
            if (weaponController.CanAttack)
            {
                Debug.Log("made it through canAttack if statment");
                weaponController.SwordAttack();
                Debug.Log("SwordAttck fuct should run");
            }
            //Rigidbody rb = Instantiate(projectile, transform.position + transform.forward, Quaternion.identity).GetComponent<Rigidbody>();

            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up, ForceMode.Impulse);


            //alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
        //}
    }

    //private void ResetAttack()
    //{
    //    alreadyAttacked = false;
    //} 

    //Animation
    public Animator enemy;
    public float maxHP = 5;
    private float hp = 5; //Private value for hp
    public float enemyHP { get { return hp; }  //Get Doesn't need any functions, since we only need to check hp when changed
        set 
        { hp = value; //Set hp equal to what it is supposed to be
            enemy.SetTrigger("Hit");
            enemyhealthbar.UpdateHealthBar(enemyHP, maxHP);
            if (hp <= 0)
            { //if has no HP left, disable the gameobject
                enemy.SetTrigger("Dead");
                enemyDead = true;
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
        enemyhealthbar.UpdateHealthBar(enemyHP, maxHP);

    }
}

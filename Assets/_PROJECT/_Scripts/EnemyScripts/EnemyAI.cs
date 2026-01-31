using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

abstract public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    [SerializeField] public EnemyStatsSO enemyStats;

    //Patroling
    public Vector3 walkPoint;
    [SerializeField] bool walkPointSet;
    public Transform groundCheck;


    //Attacking
    bool alreadyAttacked;

    //Ranges
    bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object not found in the scene. Please ensure there is a GameObject tagged 'Player'.");
        }
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, enemyStats.sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, enemyStats.attackRange, whatIsPlayer);

        if (agent.enabled == true)
        {
            if (playerInAttackRange)
            {
                AttackPlayer();
            }
            else if (playerInSightRange)
            {
                ChasePlayer();
            }
            else
            {
               Patroling();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mask"))
        {
            OnMasked();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        else if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkpoint = groundCheck.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkpoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-enemyStats.walkPointRange, enemyStats.walkPointRange);
        //float randomX = Random.Range(-enemyStats.walkPointRange, enemyStats.walkPointRange);
        walkPoint = new Vector3(0, groundCheck.position.y, groundCheck.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPos);

        if (!alreadyAttacked)
        {
            AttackAction();
            Debug.Log("Enemy Attacks!");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), enemyStats.timeBetweenAttacks);
        }
    }

    public abstract void AttackAction();

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnMasked()
    {
        GetComponent<EnemyAI>().enabled = false;

        GetComponent<NavMeshAgent>().enabled = false;
    }
}

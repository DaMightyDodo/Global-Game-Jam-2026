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
    bool walkPointSet;

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

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkpoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkpoint.magnitude < 0.1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        //float randomZ = Random.Range(-enemyStats.walkPointRange, enemyStats.walkPointRange);
        float randomX = Random.Range(-enemyStats.walkPointRange, enemyStats.walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

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

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}

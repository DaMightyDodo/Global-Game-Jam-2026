using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public EnemyStatsSO enemyStats;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

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

        if (!playerInSightRange && !playerInAttackRange) Patroling();
    }

    private void Patroling()
    {

    }

    private void ChasePlayer()
    {

    }

    private void AttackPlayer()
    {

    }
}

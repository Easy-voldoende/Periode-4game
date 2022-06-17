using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITest : MonoBehaviour
{

    public Transform player;
    public int damg;
    public float inSightRange;
    public float attackRange;
    public NavMeshAgent agent;
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        // Get distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check that distance to either follow or attack
        if(distanceToPlayer > inSightRange)
        {
            Patrol();
        }
        else if(distanceToPlayer <= inSightRange)
        {
            GotoPlayer();
        }
        else if(distanceToPlayer <= attackRange)
        {
            Attack();
        }
    }

    public void GotoPlayer()
    {
        agent.SetDestination(player.position);
    }

    public void Attack()
    {
        // HP/ damage system is crap atm, doing doing here!

    }

    public void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    public void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f))
            walkPointSet = true;
    }
}

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

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer <= inSightRange)
        {
            GotoPlayer();
        }else if(distanceToPlayer <= attackRange)
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
}

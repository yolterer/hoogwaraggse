using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    private NavMeshAgent _NavMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();    
    }

    private void InitComponentLinks()
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        PatrolUpdate();
    }

    private void PatrolUpdate()
    {
        if(_NavMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoint();
        }
    }    

    private void PickNewPatrolPoint()
    {
        _NavMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
}

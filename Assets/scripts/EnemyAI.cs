using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    // Start is called before the first frame update
    private void Start()
    {
       IntComponentLinks();
       PickNewPatrolPoit();
    }

    private void IntComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        NoticePlayerUpdate();
        PatrolUpdate();
    }

    // Update is called once per frame
    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
                
            }
            
        }
        
       PatrolUpdate();
    }
    
    private void PickNewPatrolPoit()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;        
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoit();
        }
        
    }
}

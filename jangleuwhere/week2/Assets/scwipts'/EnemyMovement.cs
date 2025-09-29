using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public List<Transform> patrolPointList = new List<Transform>();
    public int patrolPointIndex = 0;

    public void PatrolRoutine()
    {
        // We don't want to change our target until we're
        // REALLY close to the current destination
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            // Switch to the next patrol position
            patrolPointIndex++;

            // When we're past the list size, restart the loop at 0
            if (patrolPointIndex >= patrolPointList.Count)
            {
                patrolPointIndex = 0;
            }

            // Get the new position
            Vector3 patrolPosition =
     patrolPointList[patrolPointIndex].position;

            // Update the target position
            navMeshAgent.destination = patrolPosition;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RunLeucis : MonoBehaviour
{
    public GameObject curtain;
    public Transform[] patrolTransforms;
    public int patrolIndex;
    public float minimumPatrolPointDistance = 0.1f;
    public int moveSpeed;
    public Timer timeScript;
    public AudioSource correct;
    public AudioClip correctsfx;
    public bool wincheck;

    private void Start()
    {
        wincheck = false;
        curtain = GameObject.Find("Trans");
    }
    private void Update()
    {
        UpdatePatrol();
        
    }
     void OnMouseDown()
    {
        if (wincheck == false)
        {
            wincheck = true;
        wingame();

        }
    }

    private void UpdatePatrol()
    {
        // Get positions
        Vector3 targetPosition = patrolTransforms[patrolIndex].position;
        Vector3 ourPosition = transform.position;

        // The direction of A to B = B - A
        Vector3 toPatrolDelta = targetPosition - ourPosition;
        Vector3 toPatrolDirection = toPatrolDelta.normalized;

        // Remember to use deltaTime when moving things in Update
        Vector3 movement = toPatrolDirection * moveSpeed;
        transform.position += movement * Time.deltaTime;

        // Check to see if we're close enough to the goal
        float distanceToPatrolPoint = toPatrolDelta.magnitude;
        if (distanceToPatrolPoint < minimumPatrolPointDistance)
        {
            // Start following the next patrol point
            patrolIndex++;

            // Let's make sure we're in bounds on the list
            if (patrolIndex >= patrolTransforms.Length)
            {
                patrolIndex = 0;
            }
        }
    }
    void wingame()
    {
        correct.clip = (correctsfx);
        correct.Play();
        timeScript.stopTime = true;
        Debug.Log("win!");
        curtain.GetComponent<Curtain>().gamesWon++;
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        //Destroy(GameObject.FindWithTag("win"));




    }
}

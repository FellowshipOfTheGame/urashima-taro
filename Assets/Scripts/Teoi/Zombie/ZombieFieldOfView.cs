using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script based on the video from Comp-3 Interactive youtube channel, following the link https://www.youtube.com/watch?v=j1-OyLo77ss
public class ZombieFieldOfView : MonoBehaviour
{
    public float radius;
    public float delayToSearch = 1f;

    [Range(0, 360)] public float angle;

    public GameObject player;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(delayToSearch);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck2D();
            Debug.Log(canSeePlayer);
        }
    }

    private void FieldOfViewCheck2D()
    {
        // Get all the colliders inside the circle scribed by position, radius and order by targetMask
        Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);
        if (rangeChecks.Length != 0)
        {
            // The first transform is the Player transform, because the targetMask is setted as the Player Layer
            Transform target = rangeChecks[0].transform;

            // Get the direction from the zombie to the player
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            // Check if the angle between the line to the target and the line with angle/2 to this line takes the player position
            if (Vector2.Angle(target.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                // check if the vision distance and if there is an obstruction between the player and the enemy
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            // Takes only the first collider that is the Player
            Transform target = rangeChecks[0].transform;

            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;

    }
}

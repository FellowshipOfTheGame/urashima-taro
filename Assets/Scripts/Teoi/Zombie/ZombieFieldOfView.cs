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

    private NewInput newInput;

    void Start()
    {
        newInput = FindObjectOfType<NewInput>();

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

    private float GetSlope(Vector3 point0, Vector3 point1)
    {
        return ( point0.y - point1.y ) / ( point0.x - point1.x );
    }

    private void FieldOfViewCheck2D()
    {
        //* ATTENTION: The Dev lost 4 hours (actually more) trying to debug this, and the reason that the Angle
        //*            between the player and de zombie was not corrently setted was that another object was with the 'Player' layer.
        //*            So to avoid this problem, the scene must have ONLY ONE object with the Layer 'Player'.

        // Get all the colliders inside the circle scribed by position, radius and order by targetMask
        Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);
        if (rangeChecks.Length != 0)
        {
            // Tests if the player is running inside the circle where the zombie can listen
            if (newInput.isRunning)
            {
                canSeePlayer = true;
            }
            else
            {
                // The first transform is the Player transform, because the targetMask is setted as the Player Layer
                Transform target = rangeChecks[0].transform;

                // Get the direction from the zombie to the player
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                Debug.Log(Vector3.Angle(directionToTarget, transform.up));

                // Check if the angle between the line to the target and the line with angle/2 to this line takes the player position
                if (Vector3.Angle(directionToTarget, transform.up) < angle / 2)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script based on the video from Comp-3 Interactive youtube channel, following the link https://www.youtube.com/watch?v=j1-OyLo77ss
public class ZombieFieldOfView : MonoBehaviour
{
    public float radiusVision;
    public float radiusHearing;
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

        // Keeps the Collider of the player if the object with targetMask=Player is inside the circle area defined (for vision or hearing)
        Collider2D[] rangeCheckVision = Physics2D.OverlapCircleAll(transform.position, radiusVision, targetMask);
        Collider2D[] rangeCheckHearing = Physics2D.OverlapCircleAll(transform.position, radiusHearing, targetMask);

        // Checks for the vision
        if (rangeCheckVision.Length != 0)
        {            
            // The first transform is the Player transform, because the targetMask is setted as the Player Layer
            Transform target = rangeCheckVision[0].transform;

            // Get the direction from the zombie to the player
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //Debug.Log(Vector3.Angle(directionToTarget, transform.up));

            // Checks if the angle between the line to the target and the line with angle/2 to this line takes the player position
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
        else if (canSeePlayer)
            canSeePlayer = false;

        // Checks if the player is running inside the circle where the zombie can listen
        if (!canSeePlayer && rangeCheckHearing.Length != 0 && newInput.isRunning)
        {
            // The first transform is the Player transform, because the targetMask is setted as the Player Layer
            Transform target = rangeCheckHearing[0].transform;

            // Get the direction from the zombie to the player
            Vector3 directionToTarget = (target.position - transform.position).normalized;

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
    }

    private void FieldOfViewCheck()
    {
        // Keep the Collider of the player if the Player is inside the sphere area defined (for vision or hearing)
        Collider[] rangeCheckVision = Physics.OverlapSphere(transform.position, radiusVision, targetMask);
        Collider[] rangeCheckHearing = Physics.OverlapSphere(transform.position, radiusHearing, targetMask);

        // Check for the vision
        if (rangeCheckVision.Length != 0)
        {
            // Takes only the first collider transform that references the Player
            Transform target = rangeCheckVision[0].transform;

            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle (transform.forward, directionToTarget) < angle / 2)
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

        // Check for the hearing
        if (rangeCheckHearing.Length != 0)
        {
            // Takes only the first collider transform that references the Player
            Transform target = rangeCheckVision[0].transform;

            Vector3 directionToTarget = (target.position - transform.position).normalized;






        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script based on the video from Comp-3 Interactive youtube channel, following the link https://www.youtube.com/watch?v=j1-OyLo77ss
public class ZombieFieldOfView : MonoBehaviour
{
    public float radiusVision;
    public float radiusHearing;
    public float delayToSearch;

    [Range(0, 360)] public float angle;

    //public GameObject player;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [HideInInspector] public bool canSeePlayer;
    [HideInInspector] public bool stillCanSeePlayer = false;      // Even if the Zombie cannot see the player, there is a delay that the zombie still can follow the player
                                        //before the 'canSeePlayer' variable is setted to false
    public float initialFollowTime;    // This can be privated when the game launchs
    private float followTime;
    private NewInput newInput;

    [HideInInspector] public GameObject player;

    private IEnumerator coroutine;

    void Start()
    {
        newInput = FindObjectOfType<NewInput>();

        player = GameObject.FindWithTag("Player");

        StartCoroutine(FOVRoutine());
    }

    private void Update()
    {
        // Variable that controls the time that the zombie
        // still follow the player even if its is out of the field of view
        if (followTime > 0)
        {
            followTime -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        //Debug.DrawLine();
    }

    private IEnumerator WaitAndSetStillCanSee()
    {
        yield return new WaitForSeconds(followTime);
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(delayToSearch);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck2D();
            // Debug.Log(canSeePlayer);
        }
    }

    private float GetSlope(Vector3 point0, Vector3 point1)
    {
        return (point0.y - point1.y) / (point0.x - point1.x);
    }

    private void FieldOfViewCheck2D()
    {
        //* ATTENTION: The Dev took 4 hours (actually more) trying to debug this, and the reason that the Angle
        //*            between the player and the zombie was not corrently setted was becaouse another object was with the 'Player' layer.
        //*            So to avoid this problem, the scene must have ONLY ONE object with the Layer 'Player'.

        // Keeps the Collider of the player if the object with targetMask=Player is inside the circle area defined (for vision or hearing)
        Collider2D[] rangeCheckVision = Physics2D.OverlapCircleAll(transform.position, radiusVision, targetMask);
        Collider2D[] rangeCheckHearing = Physics2D.OverlapCircleAll(transform.position, radiusHearing, targetMask);

        foreach (Collider2D col in rangeCheckVision)
        {
            if (col.gameObject.name == "Jogador 1")
            {
                // Checks for the vision
                if (rangeCheckVision.Length != 0)
                {
                    Debug.Log(rangeCheckVision.Length);
                    Debug.Log("PLAYER IN VISION");
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
                            followTime = initialFollowTime;
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
        }

        foreach (Collider2D col in rangeCheckHearing)
        {
            // Checks if the player is running inside the circle where the zombie can listen
            if (col.gameObject.name == "Jogador 1" && !canSeePlayer && newInput.isRunning)
            {
                // The first transform is the Player transform, because the targetMask is setted as the Player Layer
                Transform target = rangeCheckHearing[0].transform;

                // Get the direction from the zombie to the player
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                // check if the vision distance and if there is an obstruction between the player and the enemy
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    followTime = initialFollowTime;
                    canSeePlayer = true;
                }
                else if (followTime <= 0)
                {
                    canSeePlayer = false;
                }
            }
        }

        // Checks if the zombie saw the player in the last 'initialFollowTime' seconds
        // if yes, the zombie 'remembers' to follow the player still, even if all given follow tests for 'canSeePlayer' are false
        if (followTime > 0.0f)
        {
            canSeePlayer = true;
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

        // Check for the hearing
        if (rangeCheckHearing.Length != 0)
        {
            // Takes only the first collider transform that references the Player
            Transform target = rangeCheckVision[0].transform;

            Vector3 directionToTarget = (target.position - transform.position).normalized;
        }

    }

    
}

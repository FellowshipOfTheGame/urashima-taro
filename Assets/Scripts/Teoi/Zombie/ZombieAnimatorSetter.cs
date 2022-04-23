using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Used to properly set the right animation
 * for the zombie, depending to where he is
 * looking at 
 */

public class ZombieAnimatorSetter : MonoBehaviour
{
    private float angle;
    public Animator anim;

    private void Start()
    {
        // anim = gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    { 
        angle = transform.eulerAngles.z;

        if (angle >= 315.0 || angle < 45.0 )
        {
            anim.SetInteger("direction", 0);
        }
        else if (angle >= 225.0 && angle < 315.0)
        {
            anim.SetInteger("direction", 1);
        }
        else if (angle >= 135.0 && angle < 225.0)
        {
            anim.SetInteger("direction", 2);
        }
        else if (angle >= 45.0 && angle < 135.0)
        {
            anim.SetInteger("direction", 3);
        }
    }
}

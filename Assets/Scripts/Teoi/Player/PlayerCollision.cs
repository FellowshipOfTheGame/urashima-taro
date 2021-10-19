using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isHidden;
    // Start is called before the first frame update
    void Start()
    {
        isHidden = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hideout")
        {
            isHidden = true;
        }
        else if (isHidden)
        {
            isHidden = false;
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hideout")
        {
            isHidden = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hideout")
        {
            isHidden = false;
        }
    }

    public bool IsHidden()
    {
        return isHidden;
    }
}

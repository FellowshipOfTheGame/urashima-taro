using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovG : MonoBehaviour
{
    public Animator anim;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        
	anim.SetFloat("Horizontal", movement.x);
	anim.SetFloat("Vertical", movement.y);
	anim.SetFloat("Speed", movement.magnitude);
	
	transform.position = transform.position + movement * speed * Time.deltaTime; 
    }
}

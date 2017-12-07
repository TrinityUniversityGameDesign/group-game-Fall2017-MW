﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlBossBattle : MonoBehaviour {
	private Rigidbody2D theRigidBody;
    private SpriteRenderer sR;
    private Animator animator;
	public float speed = 10;
    public int num;

	// Use this for initialization
	void Start () {
        
		theRigidBody = GetComponent<Rigidbody2D> ();
        sR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		//Horizontal movment for the character
		float inputX = GlobalControl.GetHorizontal(num);
		theRigidBody.velocity = new Vector2 (inputX * speed, theRigidBody.velocity.y);



		//makes a character jump if they press A 
		//want to make a double jump, you can only jup is you have a jump left. 
		bool jump = GlobalControl.GetButtonDownA(num);
        

		if (jump && theRigidBody.transform.position.y < (-3.10) ) {
			theRigidBody.velocity = new Vector2 (theRigidBody.velocity.x, 10);
		}
        if (transform.position.y < (-3.10))
        {
            animator.SetBool("isJumping", false);
        }else animator.SetBool("isJumping", true);
        animator.SetFloat("speed", Mathf.Abs(theRigidBody.velocity.x));

        if(theRigidBody.velocity.x < 0)
        {
            sR.flipX = false;
        }else
        {
            sR.flipX = true;
        }

    }
}

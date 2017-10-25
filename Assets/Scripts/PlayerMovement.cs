﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 5f; 
	private Rigidbody2D theRigidBody; 

	// Use this for initialization
	void Start () {
		theRigidBody = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");

		theRigidBody.velocity = new Vector2 (inputX * speed, theRigidBody.velocity.y);

		
	}
}
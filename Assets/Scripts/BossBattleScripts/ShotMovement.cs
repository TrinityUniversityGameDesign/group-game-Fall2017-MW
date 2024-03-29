﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour {

	public float speed = 5.0f;
	private Rigidbody2D theRigidBody;
	// Use this for initialization
	void Start () {
		theRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        theRigidBody.velocity = Vector3.right * speed;
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject && other.gameObject.layer == 11 || gameObject && other.gameObject.layer == 0)
        {
            gameObject.SetActive(false);
        }
    }
}

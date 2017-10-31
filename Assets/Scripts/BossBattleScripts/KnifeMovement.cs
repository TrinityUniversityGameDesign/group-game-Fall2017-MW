using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour {

	public float speed = 5.0f;
	private Rigidbody2D theRigidBody;
	// Use this for initialization
	void Start () {
		theRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		theRigidBody.velocity = new Vector2(speed, theRigidBody.velocity.y);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlBossBattle : MonoBehaviour {
	private Rigidbody2D theRigidBody; 
	public float speed = 10;
    public int num;

	// Use this for initialization
	void Start () {
        
		theRigidBody = GetComponent<Rigidbody2D> ();
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


	}
}

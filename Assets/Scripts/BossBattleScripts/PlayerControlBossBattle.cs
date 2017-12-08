using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlBossBattle : MonoBehaviour {
	private Rigidbody2D theRigidBody;
    private SpriteRenderer sR;
    private Animator animator;
    public float jumpPower = 5;
	public float speed = 10;
    public int num;
    private bool onFridge = false; 

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
        

		if (jump && theRigidBody.transform.position.y < (-3.10) || jump && onFridge) {
			theRigidBody.velocity = new Vector2 (theRigidBody.velocity.x, jumpPower);
		}
        if (onFridge)
        {
            animator.SetBool("isJumping", false);
        }
        if (transform.position.y < (-3.10) || onFridge)
        {
            animator.SetBool("isJumping", false);
        }else animator.SetBool("isJumping", true);
        animator.SetFloat("speed", Mathf.Abs(theRigidBody.velocity.x));

        if(theRigidBody.velocity.x < 0)
        {
            sR.flipX = true;
        }else
        {
            sR.flipX = false;
        }
        if (theRigidBody.transform.position.x > -7f || theRigidBody.transform.position.y > 0)
        {
            onFridge = false;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "fridge")
        {
           Debug.Log("hit the fridge");
            onFridge = true;
        }
    }
}

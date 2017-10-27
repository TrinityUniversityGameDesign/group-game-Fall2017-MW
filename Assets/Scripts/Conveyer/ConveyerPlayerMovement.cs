using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerPlayerMovement : MonoBehaviour {

	public float speed = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 ((GlobalControl.GetHorizontal (1)*0.05f*speed), (GlobalControl.GetVertical (1)*0.05f*speed), 0);
	}
}

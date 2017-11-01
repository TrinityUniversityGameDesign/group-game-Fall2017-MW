using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBossControl : MonoBehaviour {
	public ConveyorController conveyor;
	public GameObject obPreFab;
	public float speed = 6;
	private int BossPNum = 2;
	private Obstacle currentObstacle;
	// Use this for initialization
	void Start () {
		GlobalControl.AddPlayer (1);
		GlobalControl.AddPlayer (2);
		currentObstacle = Instantiate (obPreFab).GetComponent<Obstacle>();
		currentObstacle.GetComponent<AffectedByConveyor> ().conveyor = conveyor;
		currentObstacle.transform.position = new Vector3(0, 7,0);
	}
	
	// Update is called once per frame
	void Update () {
		currentObstacle.transform.position += new Vector3(GlobalControl.GetHorizontal (BossPNum)*0.05f*speed,0,0);
		//Debug.Log ("Updating " + Input.GetButton ("X_P1"));
		if(Input.GetButtonDown("X_P1")) {
			Debug.Log ("Pressed");
			currentObstacle.GetComponent<Obstacle> ().setActive(conveyor);
			currentObstacle = Instantiate (obPreFab).GetComponent<Obstacle>();
			currentObstacle.GetComponent<AffectedByConveyor> ().conveyor = conveyor;
			currentObstacle.transform.position = new Vector3(0, 7,0);
		}
	}
}

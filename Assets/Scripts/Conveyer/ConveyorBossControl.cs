﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBossControl : MonoBehaviour {
	public ConveyorController conveyor;
	public GameObject[] obPreFabs;
	public float speed = 6;
	public int frameDelay = 100;
	private int BossPNum = 2;
	private Obstacle currentObstacle;
	private int frameCt = 0;
	// Use this for initialization
	void Start () {
		GlobalControl.AddPlayer (1);
		GlobalControl.AddPlayer (2);
		currentObstacle = Instantiate (obPreFabs[Random.Range(0,obPreFabs.Length)]).GetComponent<Obstacle>();
		currentObstacle.GetComponent<AffectedByConveyor> ().conveyor = conveyor;
		currentObstacle.transform.position = new Vector3(0, 7,0);
	}
	
	// Update is called once per frame
	void Update () {
		frameCt++;
		if (currentObstacle != null) {
			
			currentObstacle.transform.position += new Vector3 (GlobalControl.GetHorizontal (BossPNum) * 0.05f * speed, 0, 0);
			//Debug.Log ("Updating " + Input.GetButton ("X_P1"));
			if (Input.GetButtonDown ("X_P1")) {
				Debug.Log ("Pressed");
				currentObstacle.GetComponent<Obstacle> ().setActive (conveyor);
				currentObstacle = null;
				frameCt = 0;

			}
		} else {
			if (frameCt > frameDelay) {
				currentObstacle = Instantiate (obPreFabs [Random.Range (0, obPreFabs.Length)]).GetComponent<Obstacle> ();
				currentObstacle.GetComponent<AffectedByConveyor> ().conveyor = conveyor;
				currentObstacle.transform.position = new Vector3 (0, 7, 0);
				frameCt = 0;
			}
		}

	}
}
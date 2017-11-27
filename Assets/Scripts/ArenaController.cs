using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour {

	private EdgeCollider2D edgeCollider;
	private Vector2[] points;

	void Awake() {
		Debug.Log ("arena awake");
		edgeCollider = GetComponent<EdgeCollider2D> ();
		points = new Vector2[62];
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetupArena(int numPlayers) {

		Debug.Log ("setup for " + numPlayers);

		float r = (float)numPlayers * 2.5f + 10f;
		float pi = Mathf.PI;

		for (int i = 0; i != 62; i++) {

			points [i].x = Mathf.Cos (2*pi * i / 60) * r;
			points [i].y = Mathf.Sin (2*pi * i / 60) * r;

			edgeCollider.points = points;

		}
	}
}

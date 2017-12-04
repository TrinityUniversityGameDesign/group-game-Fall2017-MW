using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour {

	private EdgeCollider2D edgeCollider;
	private Vector2[] points;
	public GameObject plate;

	void Awake() {
		edgeCollider = GetComponent<EdgeCollider2D> ();
		points = new Vector2[62];
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetupArena(int numPlayers) {
		plate.transform.localScale = new Vector3 (4.95f + (numPlayers - 2f) * 0.475f, 4.95f + (numPlayers - 2f) * 0.475f, 1f);
		plate.transform.position = new Vector3 (2.6f + (numPlayers - 2f) * .265f, 0, 1f);
		float r = (float)numPlayers * 1.25f + 10f;
		float pi = Mathf.PI;

		for (int i = 0; i != 62; i++) {

			points [i].x = Mathf.Cos (2*pi * i / 60) * r;
			points [i].y = Mathf.Sin (2*pi * i / 60) * r;

			edgeCollider.points = points;

		}
	}
}

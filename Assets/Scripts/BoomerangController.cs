using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : MonoBehaviour {

	public float throwingRotatingSpeed;
	public float trackingRotatingSpeed;
	public float flyingSpeed;
	public PlayerController lastHolder;
	public float delay;

	private bool trackingBack;
	private bool inTheAir;
	private Rigidbody2D rigid2d;


	void Start () {
		rigid2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inTheAir) {
			if (trackingBack) {
				Vector3 direction = (lastHolder.transform.position - transform.position).normalized;
				float zAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90;
				Quaternion correctRotation = Quaternion.Euler (0, 0, zAngle);
				transform.rotation = Quaternion.RotateTowards (transform.rotation, correctRotation, trackingRotatingSpeed * Time.deltaTime);
				rigid2d.velocity = transform.up * flyingSpeed;
			} else {
				transform.Rotate (new Vector3 (0f, 0f, throwingRotatingSpeed * Time.deltaTime));
				rigid2d.velocity = transform.up * flyingSpeed;
			}
		} else {
			Debug.Log ("not in the air");
		}
	}

	public void Throw(Vector3 upDirection) {

		Debug.Log ("set intheair true");

		transform.up = upDirection;
		inTheAir = true;
		StartCoroutine(BackToLastHolder ());
	}

	IEnumerator BackToLastHolder() {
		yield return new WaitForSeconds (delay);
		if (inTheAir) {
			trackingBack = true;
		}
	}

	public void GetHolder(GameObject player) {
		inTheAir = false;
		trackingBack = false;
		lastHolder = player.GetComponent<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			GetHolder (collider.gameObject);
		}
	}
}

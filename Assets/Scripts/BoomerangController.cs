using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : MonoBehaviour {

	public float throwingRotatingSpeed;
	public float trackingRotatingSpeed;
	public float flyingSpeed;
	public PlayerController lastHolder;
    public PlayerController temp;
	public float delay;

	private bool trackingBack;
	private bool inTheAir;
	private Rigidbody2D rigid2d;
	private PolygonCollider2D myCollider;
    public HotPotatoManager man;

	void Awake() {
		myCollider = GetComponent<PolygonCollider2D> ();
		rigid2d = GetComponent<Rigidbody2D> ();
	}
	void Start () {

	}
	
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
		} 
	}

	public void Throw(Vector3 upDirection) {
		Physics2D.IgnoreCollision (myCollider, lastHolder.myCollider, true);
		transform.up = upDirection;
		inTheAir = true;
		StartCoroutine(BackToLastHolder ());

	}

	IEnumerator BackToLastHolder() {
		yield return new WaitForSeconds (delay);
		Physics2D.IgnoreCollision (myCollider, lastHolder.myCollider, false);
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
            temp = lastHolder;
			Physics2D.IgnoreCollision (myCollider, lastHolder.myCollider, false);
			GetHolder (collider.gameObject);
            if (temp != lastHolder)
            {
                man.playerCatch();
            }
		}
	}
}

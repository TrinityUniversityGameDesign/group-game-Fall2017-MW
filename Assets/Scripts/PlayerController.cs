using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public int playerNum;
	public float speed;
	public float rotatingSpeed;
	public bool holding;

	private Rigidbody2D rigid2d;
	private SpriteRenderer spriteRenderer;
	private GameObject boomerang;
	private Transform shootingPointTransform;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rigid2d = GetComponent<Rigidbody2D> ();
		shootingPointTransform = GetComponentInChildren<Transform> ();
	}
	void Start () {
	}

	void Update () {

		float horizontal = GlobalControl.GetHorizontal(playerNum);
		float vertical = GlobalControl.GetVertical (playerNum);

		rigid2d.velocity = new Vector2 (horizontal*speed, vertical*speed);

		float horizontalAim = GlobalControl.GetHorizontalAim (playerNum);
		float verticalAim = GlobalControl.GetVerticalAim (playerNum);


		if (horizontalAim != 0f || verticalAim != 0f) {
			transform.up = new Vector3 (horizontalAim+0.01f, verticalAim, 0);
		}

		if (GlobalControl.GetButtonDownRT(playerNum)) {
			ThrowBoomerang ();
		}
	}

	public void GetBoomerang(BoomerangController controller) {
		holding = true;
		if (spriteRenderer == null) {
			Debug.Log ("null renderer");
		}
		spriteRenderer.color = Color.red;
		controller.GetHolder (this.gameObject);
		boomerang = controller.gameObject;
		boomerang.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		switch (collider.tag) {
		case "Boomerang": 
			GetBoomerang (collider.gameObject.GetComponent<BoomerangController>());
			break;
		default:
			return;
		}
	}

	private void ThrowBoomerang() {
		if (boomerang != null) {
			boomerang.transform.position = transform.position + transform.right.normalized*2f + transform.up.normalized*2f;
			boomerang.SetActive (true);
			spriteRenderer.color = Color.white;
			boomerang.GetComponent<BoomerangController> ().Throw (transform.up + 0.45f* transform.right);
			boomerang = null;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public int playerNum;
	public float speed;
	public float rotatingSpeed;
	public bool holding;
	public bool hasControl = false;

	private Rigidbody2D rigid2d;
	public CircleCollider2D myCollider;
	private SpriteRenderer spriteRenderer;
	private GameObject boomerang = null;
	private Color myColor;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rigid2d = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<CircleCollider2D> ();
	}

	void Start () {
		myColor = PlayerState.playerColor [playerNum];
		if (spriteRenderer.color != Color.yellow) 
			spriteRenderer.color = myColor;
	}

	void Update () {

		if (!hasControl)
			return;
		
		float horizontal = GlobalControl.GetHorizontal(playerNum);
		float vertical = GlobalControl.GetVertical (playerNum);

		rigid2d.velocity = new Vector2 (horizontal, vertical).normalized*speed;

		float horizontalAim = GlobalControl.GetHorizontalAim (playerNum);
		float verticalAim = GlobalControl.GetVerticalAim (playerNum);


		if (horizontalAim != 0f || verticalAim != 0f) {
			transform.up = new Vector3 (horizontalAim+0.01f, verticalAim, 0);
		}

		if (GlobalControl.GetButtonDownRT(playerNum)) {
			ThrowBoomerang ();
		}
	}

	public void GetBoomerang(BoomerangController bController) {
		Debug.Log (name + " GetBoomerang");
		holding = true;
		spriteRenderer.color = Color.yellow;
		bController.GetHolder (this.gameObject);
		boomerang = bController.gameObject;
		boomerang.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		switch (collider.tag) {
		case "Boomerang": 
			Debug.Log ("collide with boomerang");
			GetBoomerang (collider.gameObject.GetComponent<BoomerangController>());
			break;
		default:
			return;
		}
	}

	private void ThrowBoomerang() {
		if (boomerang != null) {
			boomerang.transform.position = transform.position + transform.right.normalized*1.25f + transform.up.normalized*1.25f;
			spriteRenderer.color = myColor;
			boomerang.SetActive (true);

			boomerang.GetComponent<BoomerangController> ().Throw (transform.up + 0.45f* transform.right);
			boomerang = null;
		}
	}
}
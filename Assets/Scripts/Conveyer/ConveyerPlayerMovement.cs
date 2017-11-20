using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerPlayerMovement : MonoBehaviour
{
    public int playerNum = 1;
    public float speed = 4;
    private bool canMove = true;
	private float delayDrop = 2.0f;
    private float stun = 2.0f;
	public Bounds bounds;
    // Use this for initialization
    void Start()
	{
		bounds = OrthographicBounds(transform.parent.GetComponentInChildren<Camera> ());
        //GlobalControl.AddPlayer(1);

		StartCoroutine(DropTimer(delayDrop));
    }

    // Update is called once per frame
    void Update()
    {
		var x = (GlobalControl.GetHorizontal (playerNum) * 0.05f * speed);
		var y = (GlobalControl.GetVertical (playerNum) * 0.05f * speed);
		if (transform.position.x + x > bounds.max.x) {
			Debug.Log ("Clamping "+transform.position.x+" into "+bounds.max.x);
			x = Mathf.Clamp (x, int.MinValue,0);
		}
		else if(transform.position.x + x < bounds.min.x)
			x = Mathf.Clamp (x, 0, int.MaxValue);


		/*if (transform.position.y + y > bounds.max.y) {
			Debug.Log ("Clamping y!");
			y = Mathf.Clamp (y, 0, int.MaxValue);
		}
		else if(transform.position.y + y < bounds.min.x)
			y = Mathf.Clamp (y, int.MinValue,0);*/
		
        if (canMove)
			transform.position += new Vector3(x,y, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacles") && canMove == true)
        {
            canMove = false;
            StartCoroutine(ObstacleTimer(stun));
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("ScreenBottom"))
        {
            Debug.Log("Hits Bottom.");
            gameObject.SetActive(false);
        }
    }

	public static Bounds OrthographicBounds (Camera camera)
	{
		if (!camera.orthographic)
		{
			Debug.Log(string.Format("The camera {0} is not Orthographic!", camera.name), camera);
			return new Bounds();
		}

		var t = camera.transform;
		var x = t.position.x;
		var y = t.position.y;
		var size = camera.orthographicSize * 2;
		var width = size * (float)Screen.width / Screen.height;
		var height = size;

		return new Bounds(new Vector3(x, y, 0), new Vector3(width, height, 0));
	}

    private IEnumerator ObstacleTimer(float seconds)
    {
        canMove = false;
        yield return new WaitForSeconds(seconds);
        canMove = true;
    }

    private IEnumerator DropTimer(float seconds)
    {
        gameObject.GetComponent<AffectedByConveyor>().isActive = false;
        yield return new WaitForSeconds(seconds);
        gameObject.GetComponent<AffectedByConveyor>().isActive = true;
    }
}

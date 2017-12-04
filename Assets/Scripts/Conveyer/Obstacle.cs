using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private bool isActive = false;

    public delegate void OnCollide(ConveyerPlayerMovement player);
    public event OnCollide onCollide;

    public void collision(ConveyerPlayerMovement player)
    {
        if (onCollide != null)
            onCollide(player);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive)    //isActive is true after boss drops obstacle -> Will be changed in Alex's Boss Player Script
        {
            // effect of conveyor belt -> method from alex
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.layer == LayerMask.NameToLayer("ScreenBottom"))
		{
			Debug.Log("Hits Bottom.");
			GameObject.Destroy(gameObject);
		}
	}

	public void setActive(ConveyorController c)
    {
		var con = GetComponent<AffectedByConveyor> ();
		con.conveyor = c;
		con.isActive = true;
        isActive = true;
    }

    public bool getActive()
    {
        return isActive;
    }
}

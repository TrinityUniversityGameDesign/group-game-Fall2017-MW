using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private bool isActive = false;

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

    public void setActive()
    {
        isActive = true;
    }

    public bool getActive()
    {
        return isActive;
    }
}

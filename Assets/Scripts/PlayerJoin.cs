using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoin : MonoBehaviour {

    private bool[] hasJoined = {true, false, false, false, false }; //Corresponds to controller number

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("A_P1") && hasJoined[1] == false)
        {
            hasJoined[1] = true;
            GlobalControl.AddPlayer(1);
        }
        if (Input.GetButtonDown("A_P2") && hasJoined[2] == false)
        {
            hasJoined[2] = true;
            GlobalControl.AddPlayer(2);
        }
        if (Input.GetButtonDown("A_P3") && hasJoined[3] == false)
        {
            hasJoined[3] = true;
            GlobalControl.AddPlayer(3);
        }
        if (Input.GetButtonDown("A_P4") && hasJoined[4] == false)
        {
            hasJoined[4] = true;
            GlobalControl.AddPlayer(4);
        }
    }
}

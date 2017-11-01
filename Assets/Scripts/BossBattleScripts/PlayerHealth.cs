using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {


    public float Playerhealth = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2d(Collision2D other)
    {
        if(other.gameObject.name == "knife")
        {
            Playerhealth -= 1;
            print(Playerhealth);
        }
    }
}

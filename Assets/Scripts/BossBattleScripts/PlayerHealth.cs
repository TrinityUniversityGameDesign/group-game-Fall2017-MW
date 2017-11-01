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


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject)
        {
            print("hit");
            Playerhealth -= 1;
            //Destroy(gameObject);

            print(Playerhealth);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mallet_time : MonoBehaviour {

    // Use this for initialization
    public int speed;
    public Transform t;
	void Start () {
		
	}

    // Update is called once per frame
    void Update(){
                if (Input.GetMouseButtonDown(0))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
                }
             }
    }


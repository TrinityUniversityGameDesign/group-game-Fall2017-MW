using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcoal_Track : MonoBehaviour {

    public float speed;
    public Transform lT;
    public Transform lB;
    public Transform rT;
    public Transform rB;
    private Transform target;



    // Use this for initialization
    void Start () {
        //  Vector3 ogPos = transform.position;
        transform.position = lT.position;
        target = lT;
	}
	
	// Update is called once per frame
	void Update () {
        float step = Time.deltaTime * speed;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


        if (transform.position == lT.position ) {
            target = lB;
        }
        
        if (transform.position == rT.position)
        {
            target = lT;
        }


       if (transform.position == lB.position)
        {
            
            target = rB;
        }

       if (transform.position == rB.position)
        {
            
            target = rT;
        }

	}
}

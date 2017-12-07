using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcoal_Track : MonoBehaviour {

    public float speed;
    public Transform lT;
    public Transform lB;
    public Transform rT;
    public Transform rB;
    public Transform startPoint;
    private Transform target;

    // Use this for initialization
    void Start () {
        //  Vector3 ogPos = transform.position;
        transform.position = startPoint.position;
        target = startPoint;
	}
	
	// Update is called once per frame
	void Update () {
        float step = Time.deltaTime * speed;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        /*
        if(transform.position == startPoint.position && flamingFairy.canMove == true)
        {
            target = rB;
        }

        if (transform.position == lT.position && flamingFairy.canMove == true) {
            target = lB;
        }
        
        if (transform.position == rT.position && flamingFairy.canMove == true)
        {
            target = lT;
        }


       if (transform.position == lB.position && flamingFairy.canMove == true)
        {
            
            target = rB;
        }

       if (transform.position == rB.position && flamingFairy.canMove == true )
        {
            
            target = rT;
        }
        */
	}
}

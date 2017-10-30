using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mallet_time : MonoBehaviour {

    // Use this for initialization
    private Vector3 hammerLoc;

    public Transform target;
    public float speed;
    void Start () {
        target = (GameObject.Find("target")).transform;
    }

    // Update is called once per frame
    void Update(){
        float step = speed * Time.deltaTime;
        hammerLoc = target.transform.position;
              //  if (Input.GetMouseButtonDown(0) )
               //     {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(hammerLoc.x,hammerLoc.y, transform.position.z), step);
        //    }

        if (Input.GetMouseButtonDown(0))
        {
           transform.position = 

        }

             }
    }


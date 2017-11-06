using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mallet_time : MonoBehaviour {

    // Use this for initialization
    private Vector3 hammerLoc;
   public Transform target;
    public Transform ground;
    public float speed;
    public int num;
    public bool smash;
    private Vector3 ogSpot;

   void Start()
    {
        target = (GameObject.Find("target")).transform;
        smash = false;
        ogSpot = transform.position;
            }


    void move_down_side(Vector3 loc, Vector3 gloc, float s, bool smack)
    {
        if (smack == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(loc.x, transform.position.y, transform.position.z), s);
        }
        else
        {
        
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, gloc.y, transform.position.z), s);
        }
    }
    // Update is called once per frame
    void Update(){
      
        float step = speed * Time.deltaTime;
        hammerLoc = target.transform.position;
        
         
            move_down_side(hammerLoc, ground.transform.position, step, smash);
        if (GlobalControl.GetButtonDownA(num))
        {
            smash = true;
        } 

    }
    }


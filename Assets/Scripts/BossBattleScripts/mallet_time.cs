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
    public bool flip;
    public Vector3 ogSpot;
    public float cooldown;

   void Start()
    {
        //target = (GameObject.Find("target")).transform;
        smash = false;
        ogSpot = transform.position;
        flip = false;
    }


    void move_down_side(Vector3 loc, Vector3 gloc, Vector3 og, float s, bool smack)
    {
        bool isDown = false;

        if (smack == false && isDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(loc.x, transform.position.y, transform.position.z), s);
        }
            else if(smack == true && isDown == false) 
            {
        
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, gloc.y+(5/2), transform.position.z), s);
                Debug.Log("go down");
                if (transform.position.y == gloc.y + (5 / 2))
                {
                    Debug.Log("go test");
                    isDown = true;
                    smack = false;
                flip = true;
                }
                }
         }


    void go_up(Vector3 og, float s) {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, og.y, transform.position.z), s);
        Debug.Log("go up");
        if (transform.position.y == og.y)
        {
            flip = false;
            smash = false;
        }
    }



    // Update is called once per frame
    void Update() {

        float step = speed * Time.deltaTime;
        hammerLoc = target.transform.position;

        if (flip == false)
        {
            move_down_side(hammerLoc, ground.transform.position, ogSpot, step, smash);
        } else
        {
            go_up(ogSpot, step);
        }

        if (GlobalControl.GetButtonDownA(num))
        {
            smash = true;
        }
        if(smash == true)
        {
            cooldown += 50;
        }
        if(smash == false)
        {
            cooldown -= 1;
            
        if( cooldown < 0)
            {
                cooldown = 0;
            }

        }

    }
    }


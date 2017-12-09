using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {
    public GameObject food;
    public Transform top;
    public Transform bot;
    public Transform target;
    public float speed;
	// Use this for initialization
	void Start () {
        target = top;
	}
	
	// Update is called once per frame
	void Update () {
        float step = Time.deltaTime * speed;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, target.position.y, transform.position.z), step);

        if (transform.position.y == top.position.y)
        {
            target = bot;
        }
        if(transform.position.y == bot.position.y)
        {
            target = top;
        }
    }
}

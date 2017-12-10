using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetFairy : MonoBehaviour {
    //best speed is 8
    public float speed;

    public int num;
	// Use this for initialization
	void Start () {
        /*GlobalControl.AddPlayer(1);
        GlobalControl.AddPlayer(2);
        GlobalControl.AddPlayer(3);*/
    }
	
	// Update is called once per frame
	void Update () {
        float inputX = GlobalControl.GetHorizontal(num);
        float inputY = GlobalControl.GetVertical(num);
        float stepX = inputX * Time.deltaTime*speed;
        float stepY = inputY * Time.deltaTime*speed;

        if (transform.position.x > -6.25f && inputX < 0f || transform.position.x < 9 && inputX > 0f) 
        transform.position = new Vector3(transform.position.x + stepX, transform.position.y + stepY, transform.position.z);
	}
}

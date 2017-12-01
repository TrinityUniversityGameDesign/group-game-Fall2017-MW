using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game_Start_UI : MonoBehaviour {

    RectTransform canvas;
    RectTransform text;
    Vector3 spos;
   // public float speed;
    public Text textobj;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<RectTransform>();
        spos = transform.position;
       // speed = 10f;
        textobj = GameObject.Find("Game_Start_Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(0f, speed, 0f);
        if(text.position.x < Screen.width + 50)
        {
            transform.position = new Vector3(text.position.x + 15, spos.y, spos.z);
        }
        else
        {
            Destroy(textobj);
        }
	}
}

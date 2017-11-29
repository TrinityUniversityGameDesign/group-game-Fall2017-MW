using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamingFairy : MonoBehaviour {


    public Color toColor;
  
    private Color ogColor;
    public float time;
    SpriteRenderer fairy;
    public float track;
	// Use this for initialization
	void Start () {
        fairy = GetComponent<SpriteRenderer>();
        ogColor = fairy.color; //color = (255f,255f,255f)
        time = 0.0f;
	}



	// Update is called once per frame
	void Update () {
        float t = Time.deltaTime;
        time += 0.01f;
            fairy.color = Color.LerpUnclamped(Color.white, Color.red, time);
      
    

       // fairy.color = new Color(255f, 255f-t, 255f-t);
	}
}

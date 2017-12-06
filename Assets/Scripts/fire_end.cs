using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_end : MonoBehaviour {
    public float time;
    SpriteRenderer kolor;
    public GameObject back;
    public GameObject back1;
    public GameObject back2;
    private Color temp;
    // Use this for initialization
    void Start () {
        kolor = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        time += 0.01f;
        temp = kolor.color;
        temp.a-= 1f;
        kolor.color = Color.LerpUnclamped(Color.white, temp, time);

    }
}

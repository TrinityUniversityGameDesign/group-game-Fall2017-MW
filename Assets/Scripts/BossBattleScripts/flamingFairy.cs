using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamingFairy : MonoBehaviour {


   // public Color toColor;
  
  //  private Color ogColor;

    public float time;
    SpriteRenderer fairy;
    public float track;
    public bool flameOn;
    public GameObject flam;
    public bool start;
    public static bool canMove = false;

	// Use this for initialization
	void Start () {
        fairy = GetComponent<SpriteRenderer>();
       // ogColor = fairy.color; //color = (255f,255f,255f)
        time = 0.0f;
        flam.SetActive(false);
        flameOn = false;
        start = true;
    }




	// Update is called once per frame
	void Update () {
       // float t = Time.deltaTime;
        time += 0.01f;

        if (time >= 1)
        {
            time = 0;
        }

        if(start == true)
        {
            fairy.color = Color.white;
        }

        if (flameOn == false  && start == false )
        {

            flam.layer = 0;
            flam.SetActive(false);
            gameObject.layer = 0;
            fairy.color = Color.LerpUnclamped(Color.red, Color.white, time);

        } else if(flameOn == true && canMove == true)
        {
            flam.layer = 11;
            gameObject.layer = 11;
            fairy.color = Color.LerpUnclamped(Color.white, Color.red, time);
            flam.SetActive(true);
        }


        // flame
        if(fairy.color == Color.red)
        {
            flameOn = false;
        }
        if(fairy.color == Color.white)
        {
            flameOn = true;
            start = false;
        }

        if (BossHealth.isBossOneThird == true)
        {
            canMove = true;
            flameOn = true;
        }else if(BossHealth.isBossOneThird == false)
        {
            flameOn = false;
            canMove = false;
        }


        //time

      
    

       // fairy.color = new Color(255f, 255f-t, 255f-t);
	}
}

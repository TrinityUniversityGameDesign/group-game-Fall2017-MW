using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {


    public float Playerhealth = 5;

	public float timeDelay = 300;

	public Text win;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Playerhealth <= 0)
		{
			win.GetComponent<Text> ().enabled = true;
			win.text = "Boss Win";
			timeDelay -= 1;
			if (timeDelay <= 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}
		}
		
	}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject && other.gameObject.layer == 11)
        {
            print("hit");
            Playerhealth -= 1;
            print(Playerhealth);
            if(Playerhealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

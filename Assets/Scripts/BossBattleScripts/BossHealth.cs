using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public Sprite healthImg;

    public float Bosshealth = 20;

	public Text win;

	public float timeDelay = 300;

    // Use this for initialization
    void Start()
    {
		win.GetComponent<Text> ().enabled = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if(Bosshealth <= 0)
        {
			win.GetComponent<Text> ().enabled = true;
			win.text = "Players Win";
			timeDelay -= 1;
			if (timeDelay <= 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}
        }
			
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject)
        {
            Bosshealth -= 1;
            print(Bosshealth);
        }
    }
}

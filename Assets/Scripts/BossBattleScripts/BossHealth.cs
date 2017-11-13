using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public Sprite healthImg;

    public static float Bosshealth = 50;

    float dom;
    

	public Text win;

	public float timeDelay = 300;

    public Slider healthbar;
    public static int deadPlayers = 0;

    // Use this for initialization
    void Start()
    {
        Bosshealth = 50;
        dom = Bosshealth;
        healthbar.value = healthLeft();
		win.GetComponent<Text> ().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = healthLeft();
        if(Bosshealth <= 0)
        {
			win.GetComponent<Text> ().enabled = true;
			win.text = "Players Win";
			timeDelay -= 1;
			if (timeDelay <= 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}
        }
        if (deadPlayers >= 3)
        {
            win.GetComponent<Text>().enabled = true;
            win.text = "Boss Win";
            timeDelay -= 1;
            if (timeDelay <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    
    float healthLeft()
    {
        return Bosshealth / dom;
    }
}
